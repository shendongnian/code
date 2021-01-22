      DateTime yesterday =  1.Days().Ago();
.
    public static TimeSpan Days(this int value)
    {
        return new TimeSpan(value, 0, 0, 0);
    }
    public static TimeSpan Hours(this int value)
    {
        return new TimeSpan(value, 0, 0);
    }
    public static TimeSpan Minutes(this int value)
    {
        return new TimeSpan(0, value, 0);
    }
    //...
