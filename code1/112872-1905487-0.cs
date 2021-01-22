    //establish DateTimes
    DateTime start = new DateTime(2009, 6, 14);
    DateTime end = new DateTime(2009, 12, 14);
    
    TimeSpan difference = end - start; //create TimeSpan object
    
    Console.WriteLine("Difference in days: " + difference.Days); //Extract days, write to Console.
