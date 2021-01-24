    public static int HoursSpanned(DateTime from, DateTime to)
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
    
    public static int DaysSpanned(DateTime from, DateTime to)
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
