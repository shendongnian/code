	void Main()
	{
	
		var first = new DateTime(2018, 04, 13);
		var second = new DateTime(2018, 04, 16);
	
		Console.WriteLine(weekDiff(first, second));
	}
	
	public int weekDiff(DateTime d1, DateTime d2, DayOfWeek startOfWeek = DayOfWeek.Monday)
	{
		var diff = d2.Subtract(d1);
		
		var weeks = (int)diff.Days / 7;
		
		// need to check if there's an extra week to count
		var remainingDays = diff.Days % 7;
		var cal = CultureInfo.InvariantCulture.Calendar;
		var d1WeekNo = cal.GetWeekOfYear(d1, CalendarWeekRule.FirstFullWeek, startOfWeek);
		var d1PlusRemainingWeekNo = cal.GetWeekOfYear(d1.AddDays(remainingDays), CalendarWeekRule.FirstFullWeek, startOfWeek);
		
		if (d1WeekNo != d1PlusRemainingWeekNo)
			weeks++;
			
		return weeks;
	}
