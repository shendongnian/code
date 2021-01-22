    private bool ValidateDatePeriod(string pdr, out DateTime startDate, 
    						out DateTime endDate)
    {
       string[] dates = pdr.Split('-');
    
       if (dates.Length != 2)
       {
    	   return false;
       }
    
       // no need to check for Length == 8 because the following will do it anyway
       // no need for "00:00:00" or "23:59:59" either, I prefer AddDays(1)
    
       if(!DateTime.TryParseExact(dates[0], "yyyyMMdd", null, DateTimeStyles.None, out startDate))
    	  return false;
    
       if(!DateTime.TryParseExact(dates[1], "yyyyMMdd", null, DateTimeStyles.None, out endDate))
    	  return false;
    
       endDate = endDate.AddDays(1);
       return true;
    }
