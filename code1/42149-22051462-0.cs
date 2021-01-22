    // Google Analytics does not follow ISO standards for date.
    // It numbers week 1 starting on Jan. 1, regardless what day of week it starts on.
    // It treats Sunday as the first day of the week.
    // The first and last weeks of a year are usually not complete weeks.
    public static DateTime GetStartDateTimeFromWeekNumberInYear(int year, uint weekOfYear)
    {
      if (weekOfYear == 0 || weekOfYear > 54) throw new ArgumentException("Week number must be between 1 and 54! (Yes, 54... Year 2000 had Jan. 1 on a Saturday plus 53 Sundays.)");
    
      // January 1 -- first week.
      DateTime firstDayInWeek = new DateTime(year, 1, 1);
      if (weekOfYear == 1) return firstDayInWeek;
    
      // Get second week, starting on the following Sunday.      
      do
      {
        firstDayInWeek = firstDayInWeek.AddDays(1);
      } while (firstDayInWeek.DayOfWeek != DayOfWeek.Sunday);
    
      if (weekOfYear == 2) return firstDayInWeek;
    
      // Now get the Sunday of whichever week we're looking for.
      return firstDayInWeek.AddDays((weekOfYear - 2)*7);
    }
