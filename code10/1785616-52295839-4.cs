    public long lastTimestamp = Stopwatch.GetTimestamp();
    public TimeSpan Span()
    {
        do
        {
            long oldValue = lastTimestamp;
            long currentTimestamp = Stopwatch.GetTimestamp();
            var previous = Interlocked.CompareExchange(ref lastTimestamp, currentTimestamp, oldValue);
            if (previous == oldValue)
            {
                // We effectively 'got the lock'
                var ticks = (currentTimestamp - oldValue) * 10_000_000 / Stopwatch.Frequency;
                return new TimeSpan(ticks);
            }
        } while (true);
        // Will never reach here
        // return new TimeSpan(0);
    }
