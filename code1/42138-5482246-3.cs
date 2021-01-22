       public static DateTime FirstDateOfWeek(int year, int weekOfYear)
        {
          return Timer.FirstDateOfWeekOfMonth(year, 1, weekOfYear);
        }
    
        public static DateTime FirstDateOfWeekOfMonth(int year, int month, 
        int weekOfYear)
        {
          DateTime dtFirstDayOfMonth = new DateTime(year, month, 1);
    
           //I also commented out this part:
          /*
          if (firstWeek <= 1)
          {
            weekOfYear -= 1;
          }
          */
