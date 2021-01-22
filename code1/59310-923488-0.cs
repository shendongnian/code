    // returns the number of milliseconds since Jan 1, 1970 (useful for converting C# dates to JS dates)
    public static double UnixTicks(this DateTime dt)
    {
        DateTime d1 = new DateTime(1970, 1, 1);
        DateTime d2 = dt.ToUniversalTime();
        TimeSpan ts = new TimeSpan(d2.Ticks - d1.Ticks);
        return ts.TotalMilliseconds;
    }
