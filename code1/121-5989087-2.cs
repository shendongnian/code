    // ----------------------------------------------------------------------
    private static int YearDiff( DateTime date1, DateTime date2 )
    {
      return YearDiff( date1, date2, DateTimeFormatInfo.CurrentInfo.Calendar );
    } // YearDiff
    
    // ----------------------------------------------------------------------
    private static int YearDiff( DateTime date1, DateTime date2, Calendar calendar )
    {
      if ( date1.Equals( date2 ) )
      {
        return 0;
      }
    
      int year1 = calendar.GetYear( date1 );
      int month1 = calendar.GetMonth( date1 );
      int year2 = calendar.GetYear( date2 );
      int month2 = calendar.GetMonth( date2 );
    
      // find the the day to compare
      int compareDay = date2.Day;
      int compareDaysPerMonth = calendar.GetDaysInMonth( year1, month1 );
      if ( compareDay > compareDaysPerMonth )
      {
        compareDay = compareDaysPerMonth;
      }
    
      // build the compare date
      DateTime compareDate = new DateTime( year1, month2, compareDay,
        date2.Hour, date2.Minute, date2.Second, date2.Millisecond );
      if ( date2 > date1 )
      {
        if ( compareDate < date1 )
        {
          compareDate = compareDate.AddYears( 1 );
        }
      }
      else
      {
        if ( compareDate > date1 )
        {
          compareDate = compareDate.AddYears( -1 );
        }
      }
      return year2 - calendar.GetYear( compareDate );
    } // YearDiff
