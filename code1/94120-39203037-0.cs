    namespace System
    {
         public static class DateTimeExtensions
         {
             public static Int32 DiffMonths( this DateTime start, DateTime end )
             {
                 Int32 months = 0;
                 DateTime tmp = start;
    
                 while ( tmp < end )
                 {
                     months++;
                     tmp = tmp.AddMonths( 1 );
                 }
    
                 return months;
            }
        }
    }
