    public static DateTime NextMonth(DateTime date)
    {
        DateTime nextMonth = date.AddMonths(1);
    
        if (date.Day != DateTime.DaysInMonth(date.Year, date.Month)) //is last day in month
        {
            //any other day then last day
            return nextMonth;
        }
        else
        {
           //last day in the month will produce the last day in the next month
           return date.AddDays(DateTime.DaysInMonth(nextMonth.Year, nextMonth.Month));
        }
    }
