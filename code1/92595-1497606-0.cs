      public static int GetWeekNumber(DateTime dtPassed)
      {
              CultureInfo ciCurr = CultureInfo.CurrentCulture;
              int weekNum = ciCurr.Calendar.GetWeekOfYear(dtPassed, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
              return weekNum;
      }
