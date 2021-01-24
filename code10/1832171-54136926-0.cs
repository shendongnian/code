    static public void Main(string[] args) //Entry point
    {
        MainAsync(args).GetAwaiter().GetResult();
    }
    static public Task MainAsync(string[] args) //Async entry point
    {
        await TEXT();
        Console.WriteLine("finished"); 
    }
