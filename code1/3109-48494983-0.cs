    public static DateTime GetDateInCurrentWeek(this DateTime date, DayOfWeek day)
    {
        var temp = date;
        var limit = (int)date.DayOfWeek;
        var returnDate = DateTime.MinValue;
    
        if (date.DayOfWeek == day) return date;
    
        for (int i = limit; i < 7; i++)
        {
            temp = temp.AddDays(1);
    
            if (day == temp.DayOfWeek)
            {
                returnDate = temp;
                break;
            }
        }
        if (returnDate == DateTime.MinValue)
        {
            for (int i = limit; i > -1; i++)
            {
                date = date.AddDays(-1);
    
                if (day == date.DayOfWeek)
                {
                    returnDate = date;
                    break;
                }
            }
        }
        return returnDate;
    }
