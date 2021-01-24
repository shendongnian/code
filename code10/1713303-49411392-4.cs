    public static class TechTodayExtensions
    {
         public static Subscribe( this TechToday tt )
         {
               new ConsoleObserver(tt);
         }
    }
