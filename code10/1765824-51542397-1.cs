    DateTime startingDate = DateTime.Parse("07/25/2018");//TODO Insert variable from poted form 
    DateTime endingDate = DateTime.Parse("07/08/2018");//TODO Insert variable from posted form
    List<DateTime> dates = new List<DateTime>();
    int couter = 0;
    for (DateTime dt = startingDate; dt <= endingDate; dt = dt.AddDays(1))
    {
        if (dt.DayOfWeek != DayOfWeek.Saturday && dt.DayOfWeek != DayOfWeek.Sunday)
            dates.Add(dt);
    
        else
            counter++;
    }
