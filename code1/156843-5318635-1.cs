    public static class DateTimeExtensions
    {
                                       //  milliseconds modulo 10:    0    1    2    3    4    5    6    7    8    9
        private static readonly int[]    OFFSET                  = {  0 , -1 , +1 ,  0 , -1 , +2 , +1 ,  0 , -1 , +1 } ;
        private static readonly DateTime SQL_SERVER_DATETIME_MIN = new DateTime( 1753 , 01 , 01 , 00 , 00 , 00 , 000 ) ;
        private static readonly DateTime SQL_SERVER_DATETIME_MAX = new DateTime( 9999 , 12 , 31 , 23 , 59 , 59 , 997 ) ;
        public static DateTime RoundToSqlServerDateTime( this DateTime value )
        {
            DateTime dt           = new DateTime( value.Year , value.Month , value.Day , value.Hour , value.Minute , value.Second , value.Millisecond) ;
            int      milliseconds = value.Millisecond ;
            int      t            = milliseconds % 10 ;
            int      offset       = OFFSET[ t ] ;
            DateTime rounded      = dt.AddMilliseconds( offset ) ;
            if ( rounded < SQL_SERVER_DATETIME_MIN ) throw new ArgumentOutOfRangeException("value") ;
            if ( rounded > SQL_SERVER_DATETIME_MAX ) throw new ArgumentOutOfRangeException("value") ;
            return rounded ;
        }
    }
