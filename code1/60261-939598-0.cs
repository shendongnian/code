    static DateTime GetDate(int year, int month, 
                    DayOfWeek weekDay, int week)
    {  
        DateTime first = new DateTime(year, month, 1);
        return first.AddDays(7*week + (int)weekDay - 
                             (int)first.DayOfWeek);
    }
