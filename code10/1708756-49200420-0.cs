    static void Main(string[] args)
    {
        Console.WriteLine(v);
        LongOperationAsync().GetAwaiter().GetResult();
        Console.WriteLine("Main thread finished.");
        Console.ReadKey();     
    }
