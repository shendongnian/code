    private static DateTime GetDayOfWeek(DayOfWeek dayOfWeek)
    {
    	var date = DateTime.Now;
    	if (date.DayOfWeek != dayOfWeek)
    	{
    		var direction = date.DayOfWeek > dayOfWeek ? -1D : 1D;
    		while (date.DayOfWeek != dayOfWeek)
    		{
    			date = date.AddDays(direction);
    		}
    	}
    	return date;
    }
