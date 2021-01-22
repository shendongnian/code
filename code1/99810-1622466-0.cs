    private static void Benchmark(Action act, int interval)
    {
        GC.Collect();
        Stopwatch sw = Stopwatch.StartNew();
        for (int i = 0; i < interval; i++)
        {
            act.Invoke();
        }
        sw.Stop();
        Console.WriteLine(sw.ElapsedMilliseconds);
    }
