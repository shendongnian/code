    //establish DateTimes
    DateTime start = new DateTime(2009, 6, 14);
    DateTime end = new DateTime(2009, 12, 14);
            
    TimeSpan difference = end - start; //create TimeSpan object
        
    int days = difference.TotalDays; //Extract days, counting parts of a day as nothing (rounding down).
        
    Console.WriteLine("Difference in days: " + days); //Write to Console.
