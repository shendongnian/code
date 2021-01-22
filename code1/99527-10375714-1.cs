    public int GetWorkingDays(Datetime from, DateTime to)
    {
        var dayDifference = (int)to.Subtract(from).TotalDays;
        return Enumerable
            .Range(1, dayDifference)
            .Select(x => to.AddDays(x))
            .Where(x => x.DayOfWeek != DayOfWeek.Saturday && x.DayOfWeek != DayOfWeek.Sunday)
            .Count();
    }
