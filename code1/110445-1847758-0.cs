    DateTime startDate = new DateTime(2009, 3, 10);
    DateTime stopDate = new DateTime(2009, 3, 26);
    int interval = 3;
        
    for (DateTime dateTime=startDate;
         dateTime < stopDate; 
         dateTime += TimeSpan.FromDays(interval))
    {
        
    }
