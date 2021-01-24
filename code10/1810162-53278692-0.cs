    private static string GetUpcomingDeliveryDay(string today, string[] days) 
	{
		if (days.Length == 0)
		{
			return string.Empty;	
		}
		
		if (days.Any(x => x == today.ToString())) 
		{
			return today;	
		}
		
		var day = string.Empty;
		var allDays = Enum.GetValues(typeof(DayOfWeek));
		var i = Array.IndexOf(allDays, Enum.Parse(typeof(DayOfWeek), today));
		
		while (string.IsNullOrEmpty(day))
		{
			i++;
			
			if (i >= allDays.Length) 
			{
				i = 0;	
			}
			
			if (days.Any(x => x == allDays.GetValue(i).ToString()))
			{
				day = allDays.GetValue(i).ToString();
			}
		}
		return day;
	}
