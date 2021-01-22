    DateTime firstDate = GetFirstDateOfWeek(DateTime.Parse("05/09/2012").Date,DayOfWeek.Sunday);
    DateTime lastDate = GetLastDateOfWeek(DateTime.Parse("05/09/2012").Date, DayOfWeek.Saturday);
    public static DateTime GetFirstDateOfWeek(DateTime dayInWeek, DayOfWeek firstDay)
    {
        DateTime firstDayInWeek = dayInWeek.Date;
        while (firstDayInWeek.DayOfWeek != firstDay)
            firstDayInWeek = firstDayInWeek.AddDays(-1);
        return firstDayInWeek;
    }
    public static DateTime GetLastDateOfWeek(DateTime dayInWeek, DayOfWeek firstDay)
    {
        DateTime lastDayInWeek = dayInWeek.Date;
        while (lastDayInWeek.DayOfWeek != firstDay)
            lastDayInWeek = lastDayInWeek.AddDays(1);
        return lastDayInWeek;
    }
