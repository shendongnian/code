    static DateTime GetDate(int year, int month, DayOfWeek dayOfWeek, int weekOfMonth)
    {
        // TODO: some range checking (>0, for example)
        DateTime day = new DateTime(year, month, 1);
        while (day.DayOfWeek != dayOfWeek) day = day.AddDays(1);
        day = day.AddDays(7 * (weekOfMonth - 1));
        return day;
    }
