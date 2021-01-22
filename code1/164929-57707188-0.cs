    public static DateTime AddMonthsE(this DateTime value,int numberOfMonths)
    {           
        bool isEndDate = DateTime.DaysInMonth(value.Year, value.Month) == value.Day;
        if(isEndDate)
        {
            var newDateTime = value.AddMonths(numberOfMonths);
            return new DateTime(newDateTime.Year, newDateTime.Month, DateTime.DaysInMonth(newDateTime.Year, newDateTime.Month));
        }
        return value.AddMonths(numberOfMonths);
    }
