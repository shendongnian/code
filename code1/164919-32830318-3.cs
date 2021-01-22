    public static DateTime AddMonthToEndOfMonth(DateTime date, int numberOfMonths)
    {
        DateTime nextMonth = date.AddMonths(numberOfMonths);
            
        if (date.Day != DateTime.DaysInMonth(date.Year, date.Month)) //is last day in month
        {
            //any other day then last day
            return nextMonth;
        }
        else
        {
            //if date was end of month, add remaining days
            int addDays = DateTime.DaysInMonth(nextMonth.Year, nextMonth.Month) - nextMonth.Day;
            return nextMonth.AddDays(addDays);
        }
    }
