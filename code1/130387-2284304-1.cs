    private DateTime GetEstimatedArrivalDate(DateTime currentDate)
    {
        DateTime estimatedDate; 
        if (currentDate.DayOfWeek >= DayOfWeek.Thursday)
        {
            estimatedDate = currentDate.AddDays(6);
        }
        else
        {
            estimatedDate = currentDate.AddDays(5);
        }
        return estimatedDate; 
    }
