    List<int> activeRanges;
    List<OutputDateRange> output;
    Date current = events[0].Date;
    int i = 0;
    
    while (i < events.Length;)
    {
        OutputDateRange out = new OutputDateRange();
        out.BeginDate = current;
        
        // Find ending date for this sub-range.
        while (i < events.Length && events[i].Date == current)
        {
            out.EndDate = events[i].Date;
            if (events[i].IsBegin)
                activeRanges.Add(events[i].DateRangeId);
            else
                activeRanges.Remove(events[i].DateRangeId);
            ++i;
        }
    
        foreach (int j in activeRanges)
            out.Names.Add(dateRanges[j].Name);
    
        output.Add(out);
    }
