    public IEnumerable<DateTime> DateRange(DateTime fromDate, DateTime toDate)
    {
        return Enumerable.Range(0, toDate.Subtract(fromDate).Days + 1)
                         .Select(d => fromDate.AddDays(d));
    }
