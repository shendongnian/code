    public bool ValidateWeekend(DateTime pickupDate, DateTime dropoffDate)
    {
        TimeSpan ts = dropoffDate.Subtract(pickupDate);
        if (ts.TotalDays >= 2 && ts.TotalDays <= 4)
        {
            switch (pickupDate.DayOfWeek)
            {
                case DayOfWeek.Thursday:
                    if (pickupDate.Hour >= 12)
                    {
                    	reurn DayOfWeek(dropOffDate.DayOfWeek);
                    }
                    break;
                case DayOfWeek.Friday, DayOfWeek.Saturday:
                    {
                    	return DayOfWeek(dropOffDate.DayOfWeek);
                    }
            }
        }
        return false;
    }
    
    public bool DayOfWeek(DateTime dropOffDate)
        {
	switch (dropoffDate.DayOfWeek)
		{
			case DayOfWeek.Sunday:
				{
					return true;
				}
			case DayOfWeek.Monday:
            	{
            		if (dropoffDate.Hour <= 12)
                    	{
                        	return true;
                        }
                	return false;
                }
           return false;
       }
     }
