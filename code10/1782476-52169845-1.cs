    private List<DateSpan> GetNonOverlappingTimes()
    {
        var AvailableHours = new System.Collections.Generic.List<DateSpan>();
        AvailableHours.Add(new DateSpan(new DateTime(2018, 9, 1, 5, 0, 0), 2));
        AvailableHours.Add(new DateSpan(new DateTime(2018, 9, 2, 4, 0, 0), 2));
        AvailableHours.Add(new DateSpan(new DateTime(2018, 9, 2, 5, 0, 0), 2));
        AvailableHours.Add(new DateSpan(new DateTime(2018, 9, 2, 1, 30, 0), 2));
        AvailableHours.Add(new DateSpan(new DateTime(2018, 9, 4, 5, 0, 0), 2));
    
        var BlockTimes = new System.Collections.Generic.List<DateSpan>();
        BlockTimes.Add(new DateSpan(new DateTime(2018, 9, 1, 10, 0, 0), 2));
        BlockTimes.Add(new DateSpan(new DateTime(2018, 9, 2, 5, 0, 0), 2));
        BlockTimes.Add(new DateSpan(new DateTime(2018, 9, 3, 5, 0, 0), 2));
        BlockTimes.Add(new DateSpan(new DateTime(2018, 9, 4, 4, 0, 0), 2));
    
        var availableTimes = new List<DateSpan>();
        foreach (var avail in AvailableHours)
        {
            // check if there are any block times where the start date or end date is between the start date and end date of the available time
            bool isConflict = BlockTimes.Exists(bt => (bt.StartDate >= avail.StartDate && bt.StartDate < avail.EndDate) || (bt.EndDate > avail.StartDate && bt.EndDate <= avail.EndDate));
    
            if (!isConflict)
                availableTimes.Add(avail);
        }
        return availableTimes;
    }
