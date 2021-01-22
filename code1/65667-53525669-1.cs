    You need to account for DateTime Kind too.
    public static DateTime GetTime(this DateTime d)
    {
        return new DateTime(d.TimeOfDay.Ticks, d.Kind);
    }
