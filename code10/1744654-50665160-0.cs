    public static DateTime FirstDayOfWeek(DateTime date)
    {
        DayOfWeek firstDayOfWeek= CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
        int offset = firstDayOfWeek - date.DayOfWeek;
        return date.AddDays(offset);
    }
    public static DateTime LastDayOfWeek(DateTime date)
    {
        return FirstDayOfWeek(date).AddDays(4);
    }
