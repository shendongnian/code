    DateTime StartDate = new DateTime(2009, 3, 10);
    DateTime EndDate = new DateTime(2009, 3, 26);
    int DayInterval = 3;
    
    List<DateTime> dateList = new List<DateTime>();
    while (StartDate.AddDays(DayInterval) <= EndDate)
    {
       StartDate = StartDate.AddDays(DayInterval);
       dateList.Add(StartDate);
    }
