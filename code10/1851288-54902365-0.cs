    public static async Task Main()
    {
        Console.WriteLine("Before LongOperationAsync");
        Task<int> task = LongOperationAsync();
        var result = await task;
        Console.WriteLine("After LongOperationAsync");
        Console.WriteLine("Result: {0}", result);
        Console.ReadKey();
    }
