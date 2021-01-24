    public static long ConvertToTS(DateTime datetime)
    {
        DateTime sTime = new DateTime(1970, 1, 1,0,0,0,DateTimeKind.Utc);
         
        return (long)(datetime - sTime).TotalMilliseconds;
    }
