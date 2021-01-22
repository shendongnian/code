    private static void Benchmark(Action act, int iterations)
    {
        GC.Collect();
        act.Invoke(); // run once outside of loop to avoid initialization costs
        Stopwatch sw = Stopwatch.StartNew();
        for (int i = 0; i < iterations; i++)
        {
            act.Invoke();
        }
        sw.Stop();
        Console.WriteLine((sw.ElapsedMilliseconds / iterations).ToString());
    }
