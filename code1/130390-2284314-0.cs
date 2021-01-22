private DateTime GetEstimatedArrivalDate(DateTime forDate)
{
    return GetEstimatedArrivalDate(DateTime.Now);
}
private DateTime GetEstimatedArrivalDate(DateTime forDate)
{
    DateTime estimatedDate; 
    if (forDate.DayOfWeek >= DayOfWeek.Thursday)
    {
        estimatedDate = forDate.Date.AddDays(6);
    }
    else
    {
        estimatedDate = forDate.Date.AddDays(5);
    }
    return estimatedDate; 
}
