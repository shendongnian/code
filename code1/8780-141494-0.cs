    public decimal ElapseddWorkingHours(DateTime start, DateTime finish)
    {
    	if (start.Date == finish.Date)
    		return (finish - start).TotalHours;
    
    	if (IsWorkingDay(start.Date))
    		return ElapsedWorkingHours(start, new DateTime(start.Year, start.Month, start.Day, 17, 30, 0))
    			+ ElapsedWorkingHours(start.Date.AddDays(1).AddHours(DateStartTime(start.Date.AddDays(1)), finish);
    	else
    		return ElapsedWorkingHours(start.Date.AddDays(1), finish);
    }
