    public static List<DateTime> GetWeeks(
        this DateTime month, DayOfWeek startOfWeek)
    {
        var firstOfMonth = new DateTime(month.Year, month.Month, 1);
        var daysToAdd = ((Int32)startOfWeek - (Int32)month.DayOfWeek) % 7;
        var firstStartOfWeek = firstOfMonth.AddDays(daysToAdd);
        var current = firstStartOfWeek;
        var weeks = new List<DateTime>();
        while (current.Month == month.Month)
        {
            weeks.Add(current);
            current = current.AddDays(7);
        }
        return weeks;
    }
