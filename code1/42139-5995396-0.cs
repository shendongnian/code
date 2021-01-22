    // ----------------------------------------------------------------------
    public static DateTime GetFirstDayOfWeek( int year, int weekOfYear )
    {
      return new Week( year, weekOfYear ).FirstDayStart;
    } // GetFirstDayOfWeek
