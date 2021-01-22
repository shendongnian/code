    static void Main(string[] args)
    {
        const int Counts = 3500000;
        long x = DateTime.UtcNow.Ticks;
        int k;
        for (int i = 0; i < Counts; i++) ;
        long y = DateTime.UtcNow.Ticks;
    
        int xx = Environment.TickCount;
        for (int i = 0; i < Counts; i++) ;
        int yy = Environment.TickCount;
    
        Stopwatch sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < Counts; i++);
        sw.Stop();
        long yyy = sw.ElapsedTicks;
    
        Console.WriteLine("DateTime:\t{0} ms", (y-x)/(10000.0));
        Console.WriteLine("Environment:\t{0} ms", (yy - xx));
        Console.WriteLine("StopWatch:\t{0} ms", (yyy * 1000.0)/ Stopwatch.Frequency );
        Console.ReadKey();
    }
