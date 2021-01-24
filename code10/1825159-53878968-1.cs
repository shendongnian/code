    public static List<GraphData> GetDateWiseUsage(DateTime startDate, DateTime endDate)
    {
        return Set.Where(x => x.Date >= startDate.Date && x.Date < endDate.Date)
        .Concat(GetDateRange(startDate, endDate).Select(date => new SourceData() { Date = date, TotalHours = 0 }))
        .GroupBy(x => x.Date.Date)
        .Select(x => new GraphData { Date = x.Key, TotalHoursCount = x.Sum(i => i.TotalHours) }).ToList();
    }
