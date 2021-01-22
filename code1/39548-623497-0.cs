    static DateTime LastDateOfWeekForMonth(DayOfWeek weekday, int month, int year)
    {
        DateTime d = new DateTime(year, month, 1).AddMonths(1);
        while (!(d.DayOfWeek == weekday && d.Month == month))
        {
           d = d.AddDays(-1);
        }
        return d;
    }
