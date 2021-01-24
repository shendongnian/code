    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting !");
        await ListenAsync(@"http://*:19999/");
        Console.WriteLine("Finished");
    }
