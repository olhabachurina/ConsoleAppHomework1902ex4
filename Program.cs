namespace ConsoleAppHomework1902ex4;

 class Program
{
    private static readonly object locker = new object();
    private static List<int> numbers = new List<int> { 10, 20, 30, 40, 50 };
    static async Task Main(string[] args)
    {
        Console.WriteLine("Исходная коллекция чисел:");
        PrintNumbers();
        await DecreaseNumbersAsync();
        await DecreaseNumbersAsync();
        await DecreaseNumbersAsync();

        Console.WriteLine("Коллекция чисел после трехкратного выполнения метода асинхронно:");
        PrintNumbers();
    }

    static void PrintNumbers()
    {
        lock (locker)
        {
            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }
    }
    static async Task DecreaseNumbersAsync()
    {
        await Task.Delay(100);

        lock (locker)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i] -= 5;
            }
            Console.WriteLine("После уменьшения на 5:");
            PrintNumbers();
        }
    }
}