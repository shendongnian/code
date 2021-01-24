    DateTime endingDate = DateTime.ParseExact("07/25/2018","MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);//TODO Insert variable from poted form 
    int workingDays = 5;
    List<DateTime> dates = new List<DateTime>();
    DateTime startingDate = endingDate;
    while(dates.Count<workingDays)
    {
    	if(startingDate.DayOfWeek != DayOfWeek.Sunday && startingDate.DayOfWeek != DayOfWeek.Saturday)
    	{
    		dates.Insert(0, startingDate);
    	}
    	startingDate = startingDate.AddDays(-1);
    }
