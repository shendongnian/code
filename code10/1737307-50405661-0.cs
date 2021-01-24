    public static void Main()
    {
     var firstCheck = Convert.ToDateTime("05/13/2018");
     CultureInfo ciCurr = CultureInfo.CurrentCulture;
     int weekNum = ciCurr.Calendar.GetWeekOfYear(firstCheck, 
     CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
     Console.WriteLine(weekNum);
    }
