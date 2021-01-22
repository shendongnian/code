    static void Main(string[] args)
    {
        int[] numbers = { 6, 3, 7, 4, 8 };
        Console.WriteLine("The addition result is {0}.",
            Tools.ProcessNumbers(p => Tools.AddNumbers(p), numbers));
        Console.WriteLine("The multiplication result is {0}.",
            Tools.ProcessNumbers(p => Tools.MultiplyNumbers(p), numbers));
        Console.ReadLine();
    }
