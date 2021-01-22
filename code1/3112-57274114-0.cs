    public static DateTime GetDayOfWeek(this DateTime dt, DayOfWeek day)
    {            
        int diff = (7 + (dt.DayOfWeek - DayOfWeek.Monday)) % 7;
        var monday = dt.AddDays(-1 * diff).Date;
    
        switch (day)
        {
            case DayOfWeek.Tuesday:
                return monday.AddDays(1).Date;
    
            case DayOfWeek.Wednesday:
                return monday.AddDays(2).Date;
    
            case DayOfWeek.Thursday:
                return monday.AddDays(3).Date;
    
            case DayOfWeek.Friday:
                return monday.AddDays(4).Date;
    
            case DayOfWeek.Saturday:
                return monday.AddDays(5).Date;
    
            case DayOfWeek.Sunday:
                return monday.AddDays(6).Date;
        }
    
        return monday;
    }
