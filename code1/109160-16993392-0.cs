      public static List<DateTime> Weekdays(DateTime startDate, DateTime endDate)
      {
          if (startDate > endDate)
          {
              Swap(ref startDate, ref endDate);
          }
          List<DateTime> days = new List<DateTime>();
          var ts = endDate - startDate;
          for (int i = 0; i < ts.TotalDays; i++)
          {
              var cur = startDate.AddDays(i);
              if (cur.DayOfWeek != DayOfWeek.Saturday && cur.DayOfWeek != DayOfWeek.Sunday)
                  days.Add(cur);
              //if (startingDate.AddDays(i).DayOfWeek != DayOfWeek.Saturday || startingDate.AddDays(i).DayOfWeek != DayOfWeek.Sunday)
              //yield return startingDate.AddDays(i);
          }
          return days;
      }
