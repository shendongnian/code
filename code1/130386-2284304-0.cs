    private DateTime GetEstimatedArrivalDate(DateTime currentDate)
    {
        DateTime estimatedDate; 
        if (DateTime.Now.DayOfWeek >= DayOfWeek.Thursday)
        {
            estimatedDate = currentDate.AddDays(6);
        }
        else
        {
            estimatedDate = currentDate.AddDays(5);
        }
        return estimatedDate; 
    }
