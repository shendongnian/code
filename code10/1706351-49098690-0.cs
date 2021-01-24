    static void Main(string[] args)
    {
        Console.WriteLine("Calling main async");
        Console.ReadLine();
        // We must explicitly wait for MainAsync to complete before exiting the application
        MainAsync(args).Wait();
    }
