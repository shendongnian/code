    public static class DateTimeExtensions
    {
	    ///<summary>Gets the first week day following a date.</summary>
    	///<param name="date">The date.</param>
	    ///<param name="dayOfWeek">The day of week to return.</param>
    	///<returns>The first dayOfWeek day following date, or date if it is on dayOfWeek.</returns>
    	public static DateTime Next(this DateTime date, DayOfWeek dayOfWeek) { 
	    	return date.AddDays((dayOfWeek < date.DayOfWeek ? 7 : 0) + dayOfWeek - date.DayOfWeek); 
	    }
    }
