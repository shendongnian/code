    public static DateTime NextMonth(this DateTime date)
    {
       if (date.Day != DateTime.DaysInMonth(date.Year, date.Month))
          return date.AddMonths(1);
       else 
          return date.AddDays(1).AddMonths(1).AddDays(-1);
    }
