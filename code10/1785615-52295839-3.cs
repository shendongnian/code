    public long lastTimestamp = Stopwatch.GetTimestamp();
    public TimeSpan Span()
    {
        long currentTimestamp = Stopwatch.GetTimestamp();
        var previous = Interlocked.Exchange(ref lastTimestamp, currentTimestamp);
        var ticks = (currentTimestamp - previous) * 10_000_000 / Stopwatch.Frequency;
        return new TimeSpan(ticks);
    }
