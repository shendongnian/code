    group r by new
    {
        WeekStart = GetStartOfWeek(eventTime)
        WeekDay = eventTime.DayOfWeek
    }
    ...
    private static DateTime GetStartOfWeek(DateTime date)
    {
        // Whatever implementation you want
    }
