public void CalendarDateAddSample()
{
  CalendarDateAdd calendarDateAdd = new CalendarDateAdd();
  // weekdays
  calendarDateAdd.AddWorkingWeekDays();
  // holidays
  calendarDateAdd.ExcludePeriods.Add( new Day( 2011, 4, 5, calendarDateAdd.Calendar ) );
  // working hours
  calendarDateAdd.WorkingHours.Add( new HourRange( new Time( 08, 30 ), new Time( 12 ) ) );
  calendarDateAdd.WorkingHours.Add( new HourRange( new Time( 13, 30 ), new Time( 18 ) ) );
  DateTime start = new DateTime( 2011, 4, 1, 9, 0, 0 );
  TimeSpan offset = new TimeSpan( 22, 0, 0 ); // 22 hours
  DateTime? end = calendarDateAdd.Add( start, offset );
  Console.WriteLine( "start: {0}", start );
  // > start: 01.04.2011 09:00:00
  Console.WriteLine( "offset: {0}", offset );
  // > offset: 22:00:00
  Console.WriteLine( "end: {0}", end );
  // > end: 06.04.2011 16:30:00
}
