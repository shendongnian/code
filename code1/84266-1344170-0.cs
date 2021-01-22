    private static TimeSpan MeasureExecTime(Action action, int iterations)
    {
        action(); // warm up
        var sw = Stopwatch.BeginNew();
        for (int i = 0; i < iterations; i++)
        {
            action();
        }
        return sw.Elapsed;
    }
