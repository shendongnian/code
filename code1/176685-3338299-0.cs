    private static ILookup<DateTime, double> CreateAggregatedDictionaryByDate( IEnumerable<TimeEntry> timeEntries )
    {
        return
            timeEntries
                .GroupBy(te => new {te.Date})
                .Select(group => new {group.Key.Date, Hours = group.Select(te => te.Hours).Sum()})
                .ToLookup(te => te.Date, te => te.Hours);
    }
