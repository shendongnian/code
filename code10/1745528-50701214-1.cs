    public static readonly DateTime Date01Jan1970 = new DateTime(1970, 1, 1);
    public static long MillisecondsFrom01Jan1970(DateTime dt)
    {
        return (dt.Ticks - Date01Jan1970.Ticks) / TimeSpan.TicksPerMillisecond;
    }
