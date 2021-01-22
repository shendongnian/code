    public enum Month
    {
        January = 1,
        Febuary = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }
    
    public static Nullable<DateTime> FindTheFirstDayOfAMonth(DayOfWeek dayOfWeek, Month month, int year)
    {
        // Do checking of parameters here, i.e. year being in future not past
    
        // Create a DateTime object the first day of that month
        DateTime currentDate = new DateTime(year, (int)month, 1);
    
        while (currentDate.Month == (int)month)
        {
            if (currentDate.DayOfWeek == dayOfWeek)
            {
                return currentDate;
            }
    
            currentDate = currentDate.AddDays(1);
        }
    
        return null;
    }
