    public static int? GetIso8601WeekOfYear(this DateTime? dt)
    {
    	if (!dt.HasValue) return null;
    
    	// Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
    	// be the same week# as whatever Thursday, Friday or Saturday are,
    	// and we always get those right
    	DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(dt.Value);
    	if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
    	{
    		dt = dt.Value.AddDays(3);
    	}
    
    	// Return the week of our adjusted day
    	return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(dt.Value, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
    }
