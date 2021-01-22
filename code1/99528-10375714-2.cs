    public int GetWorkingDays(DateTime from, DateTime to)
    {
        var totalDays = 0;
        for (var date = from; date < to; date = date.AddDays(1))
        {
            if (date.DayOfWeek != DayOfWeek.Saturday
                && date.DayOfWeek != DayOfWeek.Sunday)
                totalDays++;
        }
        return totalDays;
    }
