    // Calculates the number of hour strikes between the two given times
    public static int HourStrikesBetween(DateTime from, DateTime to)
    {
        if(from > to)
        {
            throw new ArgumentException("from must not be after to");
        }
        // Trim to hours
        DateTime fromTrimmed = new DateTime(from.Year, from.Month, from.Day, from.Hour, 0, 0);
        DateTime toTrimmed = new DateTime(to.Year, to.Month, to.Day, to.Hour, 0, 0);
    
        int hours = (int)(toTrimmed - fromTrimmed).TotalHours;
    
        return hours;
    }
    
    // Calculates the number of midnights between the two given times
    public static int MidnightsBetween(DateTime from, DateTime to)
    {
        if (from > to)
        {
            throw new ArgumentException("from must not be after to");
        }
    
        // Trim to days
        DateTime fromTrimmed = new DateTime(from.Year, from.Month, from.Day);
        DateTime toTrimmed = new DateTime(to.Year, to.Month, to.Day);
    
        int days = (toTrimmed - fromTrimmed).Days;
    
        return days;
    }
