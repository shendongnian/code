    public static DateTime NextMonth(this DateTime date)
    {
       if (date.Day != DateTime.DaysInMonth(date.Year, date.Month))
          return date.AddMonths(1);
       date = date.AddMonths(1);
       return date.AddDays(DateTime.DaysInMonth(date.Year, date.Month) - date.Day);
    }
