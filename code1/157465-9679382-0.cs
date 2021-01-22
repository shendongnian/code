    // convert datetime to unix epoch seconds
    public static long ToUnixTime(DateTime date)
    {
        var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        return Convert.ToInt64((date.ToUniversalTime() - epoch).TotalSeconds);
    }
