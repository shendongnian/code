    static void Main(string[] args)
    {
        //any code here...
        Console.WriteLine("Discovery started");
    
        var task = WaitMy();
    
        task.Wait();
        Console.WriteLine("And done :)");
    }
    private static Task WaitMy()
    {
        //await Task.Delay(30 * 1000);
        return Task.Run(async () => await Task.Delay(30 * 1000));
    }
