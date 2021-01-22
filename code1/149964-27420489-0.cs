    public DateTime GetLastFridayOfMonth(DateTime dt)
    {
          DateTime dtMaxValue = DateTime.MaxValue;
          DateTime dtLastDayOfMonth = new DateTime(dt.Year, dt.Month, DateTime.DaysInMonth(dt.Year, dt.Month));
    
          while (dtMaxValue == DateTime.MaxValue)
          {
               // Returns if the decremented day is the fisrt Friday from last(ie our last Friday)
               if (dtMaxValue == DateTime.MaxValue && dtLastDayOfMonth.DayOfWeek == DayOfWeek.Friday)
                   return dtLastDayOfMonth;
               // Decrements last day by one
               else
                  dtLastDayOfMonth = dtLastDayOfMonth.AddDays(-1.0);
          }
          return dtLastDayOfMonth;
    }
