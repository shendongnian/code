    static async Task Main(string[] args)
    {
    	Console.WriteLine("Done");
        T();
        U();
        Console.WriteLine("Hello");
    }
    
    public static Task T()
    {
        return Task.CompletedTask;
    }
    
    public static async Task U()
    {
        await Task.Yield();
        return;
    }
