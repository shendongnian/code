    public static DateTime GetTimestampFromJS(long ts)
    {
        DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return origin.AddSeconds(ts*1000);
    }
