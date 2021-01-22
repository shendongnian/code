    static void Main(string[] args)
    {
        DateTime t = DateTime.Now;
        DateTime p = t.PreviousMonthFirstDay();
        Console.WriteLine( p.ToShortDateString() );
        p = t.PreviousMonthLastDay();
        Console.WriteLine( p.ToShortDateString() );
        Console.ReadKey();
    }
}
    public static class Helpers
    {
        public static DateTime PreviousMonthFirstDay( this DateTime currentDate )
        {
            DateTime d = currentDate.PreviousMonthLastDay();
    
            return new DateTime( d.Year, d.Month, 1 );
        }
    
        public static DateTime PreviousMonthLastDay( this DateTime currentDate )
        {
            return new DateTime( currentDate.Year, currentDate.Month, 1 ).AddDays( -1 );
        }
    }
