    public static IEnumerable<DateRange> GetRanges(this IEnumerable<DateTime> dates)
    {
        List<DateRange> ranges = new List<DateRange>();
        DateRange currentRange = null;
        DateTime? previousDate = null;
        // this presumes a list of dates ordered by day, if not then the list will need sorting first
        foreach( var currentDate in dates )
        {
            if( previousDate == null || previousDate.Value != currentDate.AddDays(-1) )
            {
                // it's either the first date or the current date isn't consecutive to the previous so a new range is needed
                currentRange = new DateRange();
                ranges.Add(currentRange);
            }
            currentRange.Add(currentDate);
            previousDate = currentDate;
        }
        return ranges;
    }
