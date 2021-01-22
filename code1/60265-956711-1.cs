    using System;
    
    Namespace date_using_week_of_month
    {
        
        public class Example
        {
            public static DateTime WthDayDOfMonthM( int w, DayOfWeek d, DateTime month )
            {
                return first( d, month ).AddDays( 7 * (w - 1) );
            }
    
            private static DateTime first( DayOfWeek d, DateTime month )
            {
                DateTime first = new DateTime(
                    month.Year, month.Month, 1 );
                while ( first.DayOfWeek != d )
                {
                    first = first.AddDays( 1 );
                }
                return first;
            }
        }
    }
