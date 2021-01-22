    static void Benchmark(Action action, int iterationCount, string text)
    {
        GC.Collect();
        var sw = new Stopwatch();
        action(); // Execute once before
        sw.Start();
        for (var i = 0; i <= iterationCount; i++)
        {
            action();
        }
        sw.Stop();
        System.Console.WriteLine(text + ", Elapsed: {0}ms", sw.ElapsedMilliseconds);
    }
