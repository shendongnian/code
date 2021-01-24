    static async Task Main(string[] args)
    {
        var longTask = LongRunningOperation();
        Console.WriteLine("Nothing to do while the awaits complete, expecting this line to come first.");
        var result = await longTask;
        Console.WriteLine($"Long running operation result: {result}");
    }
