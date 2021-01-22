    public static void WriteX()
    {
        var sw = Stopwatch.StartNew();
        for (int i = 1; i <= 3; i++)
        {
            Console.WriteLine("Hello");
            Thread.Sleep(1000);
        }
        sw.Stop();
        Console.WriteLine("{0} {1}", 
                          Thread.CurrentThread.ManagedThreadId, 
                          sw.Elapsed);
    }
