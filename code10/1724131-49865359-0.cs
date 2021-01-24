    private static async Task Main(string[] args)
    {
        Task<string> resultTask = HashAsync(Guid.NewGuid().ToByteArray(), 4);
        Console.WriteLine("Calculating hash...");'
        string result = await resultTask;
        Console.WriteLine(result);
        Console.Read();
    }
