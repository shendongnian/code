    public DateTime GetFirstDayOfWeekInMonth(int year, int month, DayOfWeek dayOfWeek)
    {
        DateTime dt = new DateTime(year, month, 1);
    	int first = (int)dt.DayOfWeek;
    	int wanted = (int)dayOfWeek;
    	if (wanted < first)
    	    wanted += 7;
    	return dt.AddDays(wanted - first);
    }
    
    public DateTime GetLastDayOfWeekInMonth(int year, int month, DayOfWeek dayOfWeek)
    {
        int daysInMonth = CultureInfo.CurrentCulture.Calendar.GetDaysInMonth(year, month);
    	DateTime dt = new DateTime(year, month, daysInMonth);
    	int last = (int)dt.DayOfWeek;
    	int wanted = (int)dayOfWeek;
    	if (wanted > last)
    	    last += 7;
    	return dt.AddDays(wanted - last);
    }
