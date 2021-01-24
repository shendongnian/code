    public static async Task Main()
    {
        Console.WriteLine("Before LongOperationAsync");
        
        int result = await LongOperationAsync();
        
        Console.WriteLine("After LongOperationAsync");
        Console.WriteLine("Result: {0}", result);
        Console.ReadKey();
    }
