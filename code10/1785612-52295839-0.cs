    public long lastTimestamp = Stopwatch.GetTimestamp();
    
    public TimeSpan Span()
    {
        long currentTimestamp = Stopwatch.GetTimestamp();
    
        var previous = Interlocked.Exchange(ref lastTimestamp, currentTimestamp);
    
        return new TimeSpan(currentTimestamp - previous);
    }
