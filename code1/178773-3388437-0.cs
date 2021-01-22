    DateTime currentDate = new DateTime(2010, 1, 1);
    DateTime endDate = new DateTime(2010, 1, 6);
    List<DateTime> existingDates = new List<DateTime>; //You fill with values
    List<DateTime> missingDates = new List<DateTime>;
    
    while(currentDate <= endDate)
    {
        if(existingDates.contains(currentDate))
            missingDates.Add(currentDate);
    
        //Increment date
        currentDate = currentDate.AddDays(1);
    }
