    IEnumerable<DateTime> WeekdaysFrom( DateTime start )
    {
        DateTime weekday = start.Add( TimeSpan.FromDays(1) );
        while( weekday < DateTime.MaxValue.Subtract( TimeSpan.FromDays(1) ) )
        {
            while( weekday.DayOfWeek == DayOfWeek.Saturday || weekday.DayOfWeek == DayOfWeek.Sunday )
            {
                weekday.Add( TimeSpan.FromDays(1) );
            }
            yield return weekday;
        }
    }
    
    DateTime NthWeekday( DateTime month, int n )
    {
        return WeekdaysFrom( new DateTime( month.year, month.month, 1 ) ).Skip(n-1).First();
    }
