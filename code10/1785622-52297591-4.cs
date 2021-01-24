    public static long Span()
    {
        long previous;
        long current;
        do
        {
            previous = lastTimestamp;
            current = Stopwatch.GetTimestamp();
        }
        while (previous != Interlocked.CompareExchange(ref lastTimestamp, current, previous));
        return current - previous;
    }
    static long lastTimestamp = Stopwatch.GetTimestamp();
