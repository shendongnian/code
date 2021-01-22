    DateTime fileDate, closestDate;
    ArrayList theDates;
    int min = 0;
    
    foreach (DateTime date in theDates)
     if (Math.Abs(date.Millisecond - fileDate.Millisecond) < min)
     {
       min = date.Millisecond - fileDate.Millisecond;
       closestDate = date;
     }
