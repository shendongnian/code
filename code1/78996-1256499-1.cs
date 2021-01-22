    public static DateTime RoundToMinute(DateTime time)
    {
        return new DateTime(time.Year, time.Month, time.Day,
                            time.Hour, time.Minute, 0, time.Kind);
    }
    
