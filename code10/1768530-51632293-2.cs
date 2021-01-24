    DateTime startTime = DateTime.Parse("2018/07/28 11:54");
    DateTime endTime = DateTime.Parse("2018/08/01 09:28");    
  
     private static double DateDurationCalculate(DateTime startTime, DateTime endTime)
     {
         TimeSpan span = endTime.Date.Subtract(startTime.Date);
         return span.TotalDays;  //return 4
     }
