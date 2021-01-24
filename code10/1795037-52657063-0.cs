	public Boolean ValidateDay()
	{
		try
		{
			int daysInMonth = DateTime.DaysInMonth(Year, Month);
			return Day >= 1 && Day <= daysInMonth;
		}
		catch (ArgumentOutOfRangeException)
		{
			return false;
		}
	}
	
	public Boolean IsLeapYear()
	{
		try
		{
			return DateTime.IsLeapYear(Year);
		}
		catch (ArgumentOutOfRangeException)
		{
			return false;
		}
	}
