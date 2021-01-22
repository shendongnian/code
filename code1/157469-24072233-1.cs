    DateTime _epochTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    private DateTime UnixTimeToDateTime(Timeval unixTime)
    {
        return _epochTime.AddTicks(
            unixTime.Seconds * TimeSpan.TicksPerSecond +
            unixTime.Microseconds * TimeSpan.TicksPerMillisecond/1000);
    }
