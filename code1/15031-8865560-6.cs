    static void Main(string[] args)
    {
        int xcnt = 0;
        long xdelta, xstart;
        xstart = DateTime.UtcNow.Ticks;
        do {
            xdelta = DateTime.UtcNow.Ticks - xstart;
            xcnt++;
        } while (xdelta == 0);
        Console.WriteLine("DateTime:\t{0} ms, in {1} cycles", xdelta / (10000.0), xcnt);
        int ycnt = 0, ystart;
        long ydelta;
        ystart = Environment.TickCount;
        do {
            ydelta = Environment.TickCount - ystart;
            ycnt++;
        } while (ydelta == 0);
        Console.WriteLine("Environment:\t{0} ms, in {1} cycles ", ydelta, ycnt);
        Stopwatch sw = new Stopwatch();
        int zcnt = 0;
        long zstart, zdelta;
        sw.Start();
        zstart = sw.ElapsedTicks; // This minimizes the difference (opposed to just using 0)
        do {
            zdelta = sw.ElapsedTicks - zstart;
            zcnt++;
        } while (zdelta == 0);
        sw.Stop();
        Console.WriteLine("StopWatch:\t{0} ms, in {1} cycles", (zdelta * 1000.0) / Stopwatch.Frequency, zcnt);
        Console.ReadKey();
    }
