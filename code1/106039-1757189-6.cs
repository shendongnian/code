    DateTime fileDate, closestDate;
    ArrayList theDates;
    long min = long.MaxValue;
    
    foreach (DateTime date in theDates)
     if (Math.Abs(date.Ticks- fileDate.Ticks) < min)
     {
       min = date.Ticks- fileDate.Ticks;
       closestDate = date;
     }
