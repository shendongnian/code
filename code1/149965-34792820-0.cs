    private DateTime GetLastFridayOfTheMonth(DateTime date)
    {
        var lastDayOfMonth = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
        while (lastDayOfMonth.DayOfWeek != DayOfWeek.Friday)
            lastDayOfMonth = lastDayOfMonth.AddDays(-1);
        return lastDayOfMonth;
    }
