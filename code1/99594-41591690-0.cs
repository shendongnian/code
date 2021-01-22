    public static int CalculateWorkingDays(
    	DateTime startDate, 
    	DateTime endDate, 
    	IList<DateTime> holidays, 
    	DayOfWeek firstDayOfWeek,
    	DayOfWeek lastDayOfWeek)
    {
    	// Make sure the defined working days run contiguously
    	if (lastDayOfWeek < firstDayOfWeek)
    	{
    		throw new Exception("Last day of week cannot fall before first day of week!");
    	}
    	// Create a list of the days of the week that make-up the weekend by working back
    	// from the firstDayOfWeek and forward from lastDayOfWeek to get the start and end
    	// the weekend
    	var weekendStart = lastDayOfWeek == DayOfWeek.Saturday ? DayOfWeek.Sunday : lastDayOfWeek + 1;
    	var weekendEnd = firstDayOfWeek == DayOfWeek.Sunday ? DayOfWeek.Saturday : firstDayOfWeek - 1;
    	var weekendDays = new List<DayOfWeek>();
    	
    	var w = weekendStart;
    	do {
    		weekendDays.Add(w);
    		if (w == weekendEnd) break;
    		w = (w == DayOfWeek.Saturday) ? DayOfWeek.Sunday : w + 1;
    	} while (true);
    	
    	// Force simple dates - no time
    	startDate = startDate.Date;
    	endDate = endDate.Date;
    	// Ensure a progessive date range
    	if (endDate < startDate)
    	{
    		var t = startDate;
    		startDate = endDate;
    		endDate = t;
    	}
    	
    	// setup some working variables and constants
    	const int daysInWeek = 7;			// yeah - really!
    	var actualStartDate = startDate;	// this will end up on startOfWeek boundary
    	var actualEndDate = endDate;		// this will end up on weekendEnd boundary
    	int workingDaysInWeek = daysInWeek - weekendDays.Count;
    	
    	int workingDays = 0;		// the result we are trying to find
    	int leadingDays = 0;		// the number of working days leading up to the firstDayOfWeek boundary
    	int trailingDays = 0;		// the number of working days counting back to the weekendEnd boundary
    	
    	// Calculate leading working days
    	// if we aren't on the firstDayOfWeek we need to step forward to the nearest
    	if (startDate.DayOfWeek != firstDayOfWeek)
    	{
    		var d = startDate;
    		do {
    			if (d.DayOfWeek == firstDayOfWeek || d >= endDate)
    			{
    				actualStartDate = d;
    				break;	
    			}
    			if (!weekendDays.Contains(d.DayOfWeek))
    			{
    				leadingDays++;
    			}
    			d = d.AddDays(1);
    		} while(true);
    	}
    	// Calculate trailing working days
    	// if we aren't on the weekendEnd we step back to the nearest
    	if (endDate >= actualStartDate && endDate.DayOfWeek != weekendEnd)
    	{
    		var d = endDate;
    		do {
    			if (d.DayOfWeek == weekendEnd || d < actualStartDate)
    			{
    				actualEndDate = d;
    				break;	
    			}
    			if (!weekendDays.Contains(d.DayOfWeek))
    			{
    				trailingDays++;
    			}
    			d = d.AddDays(-1);
    		} while(true);
    	}
    	// Calculate the inclusive number of days between the actualStartDate and the actualEndDate
    	var coreDays = (actualEndDate - actualStartDate).Days + 1;
    	var noWeeks =  coreDays / daysInWeek;
    	// add together leading, core and trailing days
    	workingDays +=  noWeeks * workingDaysInWeek;
    	workingDays += leadingDays;
    	workingDays += trailingDays;
    	// Finally remove any holidays that fall within the range.
    	if (holidays != null)
    	{
    		workingDays -= holidays.Count(h => h >= startDate && (h <= endDate));
    	}
    	
        return workingDays;
    }
