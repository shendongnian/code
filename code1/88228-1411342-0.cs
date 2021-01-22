    public static DateTime WithTime(this DateTime date, TimeSpan time)
    {
        return date.Date + time;
    }
    public static DateTime WithDate(this DateTime original, DateTime newDate)
    {
        return newDate.WithTime(original);
    }
    public static DateTime WithTime(this DateTime original, DateTime newTime)
    {
        return original.Date + newTime.TimeOfDay;
    }
