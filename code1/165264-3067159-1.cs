    static int GetWeeksCovered(DateTime startDate, DateTime endDate)
    {
        if (endDate < startDate)
            throw new ArgumentException("endDate cannot be less than startDate");
        return (GetBeginningOfWeek(endDate).Subtract(GetBeginningOfWeek(startDate)).Days / 7) + 1;
    }
    static DateTime GetBeginningOfWeek(DateTime date)
    {
        return date.AddDays(-1 * (int)date.DayOfWeek).Date;
    }
