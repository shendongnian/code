    public static IEnumerable<DateTime> GetDaysInMonth(DateTime d)
    {
        d = new DateTime(d.Year, d.Month, 1);
        return Enumerable.Range(0, DateTime.DaysInMonth(d.Year, d.Month))
                 .Select(i => d.AddDays(i) );
    }
