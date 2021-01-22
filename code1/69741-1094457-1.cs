    int c = DaysBetween(begin, end).Count(d => d.DayOfWeek != DayOfWeek.Sunday);
    private IEnumerable<DateTime> DaysBetween(DateTime begin, DateTime end)
    {
        for(var d = begin; d <= end; d.AddDays(1)) yield return d;
    }
