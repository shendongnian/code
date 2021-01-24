    public int DaysLeft(DateTime startDate, DateTime endDate, Boolean excludeWeekends, List<DateTime> excludeDates) {
        int count = 0;
        for (DateTime index = startDate; index <= endDate; index = index.AddDays(1)) {
            if (excludeWeekends && (index.DayOfWeek == DayOfWeek.Sunday || index.DayOfWeek == DayOfWeek.Saturday))
                continue;
            if (excludeDates.Contains(index.Date))
                continue;
            count++;
        }
        return count;
    }
