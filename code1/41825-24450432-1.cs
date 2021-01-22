    // Calculate the week number according to ISO 8601
    
        public static int Iso8601WeekNumber(DateTime dt)
        {
                return  CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(dt, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
    
    // ...
    
    DateTime dt = DateTime.Now;
    
    // Calculate the WeekOfMonth according to ISO 8601
    int weekOfMonth = Iso8601WeekNumber(dt) - Iso8601WeekNumber(dt.AddDays(1 - dt.Day)) + 1;
