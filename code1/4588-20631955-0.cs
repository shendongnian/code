    static void Main(string[] args)
    {
        Console.WriteLine("Hit q to continue or wait 10 seconds.");
    
        Task task = Task.Factory.StartNew(() => loop());
    
        Console.WriteLine("Started waiting");
        task.Wait(10000);
        Console.WriteLine("Stopped waiting");
    }
    
    static void loop()
    {
        while (true)
        {
            if ('q' == Console.ReadKey().KeyChar) break;
        }
    }
