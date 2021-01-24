    public static int MillisecondsTimestamp(this DateTime date)
    {
        DateTime baseDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        return (int)(date.ToUniversalTime()-baseDate).TotalMilliseconds;
    }
