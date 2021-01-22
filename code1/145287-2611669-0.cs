    Date selectedStart = Date.MinValue;
    PricingActivity selected = sortedList[0];
    foreach(PricingActivity act in sortedList)
    {
    	if (act.Start >= selected.End ||
    		act.Priority > selected.Priority)
    	{
    		// Store the selected activity with the applicable date range.
    		selectedActivities.Add(
                    new DateRange(selectedStart, Math.Min(selected.End, act.Start)),
                    selected);
    		// The next activity (act) would start here.
    		selectedStart = act.Start;
    		selected = act;
    	}
    }
