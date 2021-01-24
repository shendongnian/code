    public static DateTime LongToDate(long javaTimeStamp)
    {
        // Java timestamp is milliseconds past epoch
        var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        dtDateTime = dtDateTime.AddMilliseconds(javaTimeStamp).ToLocalTime();
        return dtDateTime;
    }
