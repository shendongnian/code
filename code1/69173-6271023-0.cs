    // ----------------------------------------------------------------------
    public void DateDiffSample()
    {
      DateTime date1 = new DateTime( 2009, 11, 8, 7, 13, 59 );
      Console.WriteLine( "Date1: {0}", date1 );
      // > Date1: 08.11.2009 07:13:59
      DateTime date2 = new DateTime( 2011, 3, 20, 19, 55, 28 );
      Console.WriteLine( "Date2: {0}", date2 );
      // > Date2: 20.03.2011 19:55:28
    
      DateDiff dateDiff = new DateDiff( date1, date2 );
    
      // differences
      Console.WriteLine( "DateDiff.Years: {0}", dateDiff.Years );
      // > DateDiff.Years: 1
      Console.WriteLine( "DateDiff.Quarters: {0}", dateDiff.Quarters );
      // > DateDiff.Quarters: 5
      Console.WriteLine( "DateDiff.Months: {0}", dateDiff.Months );
      // > DateDiff.Months: 16
      Console.WriteLine( "DateDiff.Weeks: {0}", dateDiff.Weeks );
      // > DateDiff.Weeks: 70
      Console.WriteLine( "DateDiff.Days: {0}", dateDiff.Days );
      // > DateDiff.Days: 497
      Console.WriteLine( "DateDiff.Weekdays: {0}", dateDiff.Weekdays );
      // > DateDiff.Weekdays: 71
      Console.WriteLine( "DateDiff.Hours: {0}", dateDiff.Hours );
      // > DateDiff.Hours: 11940
      Console.WriteLine( "DateDiff.Minutes: {0}", dateDiff.Minutes );
      // > DateDiff.Minutes: 716441
      Console.WriteLine( "DateDiff.Seconds: {0}", dateDiff.Seconds );
      // > DateDiff.Seconds: 42986489
    
      // elapsed
      Console.WriteLine( "DateDiff.ElapsedYears: {0}", dateDiff.ElapsedYears );
      // > DateDiff.ElapsedYears: 1
      Console.WriteLine( "DateDiff.ElapsedMonths: {0}", dateDiff.ElapsedMonths );
      // > DateDiff.ElapsedMonths: 4
      Console.WriteLine( "DateDiff.ElapsedDays: {0}", dateDiff.ElapsedDays );
      // > DateDiff.ElapsedDays: 12
      Console.WriteLine( "DateDiff.ElapsedHours: {0}", dateDiff.ElapsedHours );
      // > DateDiff.ElapsedHours: 12
      Console.WriteLine( "DateDiff.ElapsedMinutes: {0}", dateDiff.ElapsedMinutes );
      // > DateDiff.ElapsedMinutes: 41
      Console.WriteLine( "DateDiff.ElapsedSeconds: {0}", dateDiff.ElapsedSeconds );
      // > DateDiff.ElapsedSeconds: 29
    
      // description
      Console.WriteLine( "DateDiff.GetDescription(1): {0}", dateDiff.GetDescription( 1 ) );
      // > DateDiff.GetDescription(1): 1 Year
      Console.WriteLine( "DateDiff.GetDescription(2): {0}", dateDiff.GetDescription( 2 ) );
      // > DateDiff.GetDescription(2): 1 Year 4 Months
      Console.WriteLine( "DateDiff.GetDescription(3): {0}", dateDiff.GetDescription( 3 ) );
      // > DateDiff.GetDescription(3): 1 Year 4 Months 12 Days
      Console.WriteLine( "DateDiff.GetDescription(4): {0}", dateDiff.GetDescription( 4 ) );
      // > DateDiff.GetDescription(4): 1 Year 4 Months 12 Days 12 Hours
      Console.WriteLine( "DateDiff.GetDescription(5): {0}", dateDiff.GetDescription( 5 ) );
      // > DateDiff.GetDescription(5): 1 Year 4 Months 12 Days 12 Hours 41 Mins
      Console.WriteLine( "DateDiff.GetDescription(6): {0}", dateDiff.GetDescription( 6 ) );
      // > DateDiff.GetDescription(6): 1 Year 4 Months 12 Days 12 Hours 41 Mins 29 Secs
    } // DateDiffSample
