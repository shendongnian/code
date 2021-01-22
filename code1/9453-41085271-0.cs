    static void ThreadMethod()
    {
        while(!autoResetEvent.WaitOne(TimeSpan.FromSeconds(2)))
        {
            Console.WriteLine("Continue");
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }
     
        Console.WriteLine("Thread got signal");
    }
