	public Boolean ValidateDay()
	{
		try
		{
			return Day >= 1 && Day <= DateTime.DaysInMonth(Year, Month);
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
