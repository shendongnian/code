    public static List<DateTime> GetLastWorkingDays(DateTime date)
    {
        List<DateTime> result = new List<DateTime>();
        date = new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1);
        while(result.Count < 3)
        {
            // > 0 to exclude sunday, < 6 to exclude saturday
            if((int)date.DayOfWeek > 0 && (int)date.DayOfWeek < 6)
            {
                result.Add(date);
            }
            date = date.AddDays(-1);
        }
        return result;
    }
