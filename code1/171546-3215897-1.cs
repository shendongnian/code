    private static DateTime GetDayOfWeek(DayOfWeek dayOfWeek)
    {
    	var date = DateTime.Now;
    	if (date.DayOfWeek != dayOfWeek)
    	{
            var direction = date.DayOfWeek > dayOfWeek ? -1D : 1D;
            do
            {
                date = date.AddDays(direction);
            } while (date.DayOfWeek != dayOfWeek);
    	}
    	return date;
    }
