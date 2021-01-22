    public int GetWorkingDays(DateTime from, DateTime to)
    {
        var dayDifference = (int)to.Subtract(from).TotalDays;
        return Enumerable
            .Range(1, dayDifference)
            .Select(x => from.AddDays(x))
            .Count(x => x.DayOfWeek != DayOfWeek.Saturday && x.DayOfWeek != DayOfWeek.Sunday);
    }
