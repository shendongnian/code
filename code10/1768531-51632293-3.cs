    DateTime startTime = DateTime.Parse("2018/07/28 11:54");
    DateTime endTime = DateTime.Parse("2018/08/01 09:28");    
  
    private static double DateDurationCalculate(DateTime startTime, DateTime endTime)
    {
        startTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, startTime.Hour, startTime.Minute, 0);
        endTime = new DateTime(endTime.Year, endTime.Month, endTime.Day, endTime.Hour, endTime.Minute, 0);
        TimeSpan span = endTime.Date.Subtract(startTime.Date);
        return span.TotalDays;
    }
