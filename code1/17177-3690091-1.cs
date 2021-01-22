    private static readonly DateTime EPOCH = DateTime.SpecifyKind(new DateTime(1970, 1, 1, 0, 0, 0, 0),DateTimeKind.Utc);
    
    public static DateTime FromUnixTimestamp(long timestamp)
    {
        return EPOCH.AddSeconds(timestamp);
    }
    
    public static long ToUnixTimestamp(DateTime date)
    {
        TimeSpan diff = date.ToUniversalTime() - EPOCH;
        return (long)diff.TotalSeconds;
    }
    
    public static DateTime FromIso8601FormattedDateTime(string iso8601DateTime){
        return DateTime.ParseExact(iso8601DateTime, "o", System.Globalization.CultureInfo.InvariantCulture);
    }
    
    public static string ToIso8601FormattedDateTime(DateTime dateTime)
    {
        return dateTime.ToString("o");
    }
