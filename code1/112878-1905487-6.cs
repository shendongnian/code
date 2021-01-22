    //establish DateTimes
    DateTime start = new DateTime(2009, 6, 14);
    DateTime end = new DateTime(2009, 12, 14);
        
    TimeSpan difference = end - start; //create TimeSpan object
    
    int days = (int)Math.Ceiling(difference.TotalDays); //Extract days, counting parts of a day as a full day (rounding up).
    
    Console.WriteLine("Difference in days: " + days); //Write to Console.
 
