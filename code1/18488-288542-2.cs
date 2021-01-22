    public static DateTime FindTheNthSpecificWeekday(int year, int month,int nth, System.DayOfWeek day_of_the_week)
    {
        // validate month value
        if(month < 1 || month > 12)
        {
            throw new ArgumentOutOfRangeException("Invalid month value.");
        }
    
        // validate the nth value
        if(nth < 0 || nth > 5)
        {
            throw new ArgumentOutOfRangeException("Invalid nth value.");
        }
    
        // start from the first day of the month
        DateTime dt = new DateTime(year, month, 1);
    
        // loop until we find our first match day of the week
        while(dt.DayOfWeek != day_of_the_week)
        {
            dt = dt.AddDays(1);
        }
    
        if(dt.Month != month)
        {
            // we skip to the next month, we throw an exception
            throw new ArgumentOutOfRangeException(string.Format("The given month has less than {0} {1}s", nth, day_of_the_week));
        }
    
        // Complete the gap to the nth week
        dt = dt.AddDays((nth - 1) * 7);
    
        return dt;
    }
