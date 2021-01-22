    public static TimeSpan MeasureExecTime(Action action)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        action();
        return stopwatch.Elapsed;
    }
