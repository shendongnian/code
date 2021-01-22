    static void Main()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        System.Threading.Thread.Sleep(3456);
        sw.Stop();
        long ticks = sw.ElapsedTicks;
        double ns = 1000000000.0 * (double)ticks / Stopwatch.Frequency;
        double ms = ns / 1000000.0;
        double s = ms / 1000;
        Console.WriteLine("{0}, {1}, {2}", ns, ms, s);
        Console.ReadKey();
    }
