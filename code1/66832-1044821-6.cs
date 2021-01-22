    public static int GetBusinessDays(DateTime start, DateTime end)
    {
        if (start.DayOfWeek == DayOfWeek.Saturday)
        {
            start = start.AddDays(2);
        }
        else if (start.DayOfWeek == DayOfWeek.Sunday)
        {
            start = start.AddDays(1);
        }
        if (end.DayOfWeek == DayOfWeek.Saturday)
        {
            end = end.AddDays(-1);
        }
        else if (end.DayOfWeek == DayOfWeek.Sunday)
        {
            end = end.AddDays(-2);
        }
        int diff = (int)end.Subtract(start).TotalDays;
        int result = diff / 7 * 5 + diff % 7;
        if (end.DayOfWeek < start.DayOfWeek)
        {
            return result - 2;
        }
        else{
            return result;
        }
    }
