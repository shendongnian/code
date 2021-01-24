    static async Task Main(string[] args)
    {
        var results = await new Task.WhenAll(
            Enumerable.Range(0, 100)
            Select(i => DoAsyncJob(I)));
    
        Console.ReadLine();
    }
