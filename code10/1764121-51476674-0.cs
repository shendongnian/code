    // Returns a list of the dates of the Business Days between the given start and end date
    public static IEnumerable<DateTime> GetBusinessDaysInRange(DateTime startDate, DateTime endDate, DayOfWeek[] closedOn) {
       if (endDate < startDate) {
		    throw new ArgumentException("endDate must be before startDate");	
	   }
    		
        var businessDays = new List<DateTime>();
    	var date = startDate;
    		
    	while (date < endDate) {
    		if (!closedOn.Contains(date.DayOfWeek)) {
    			businessDays.Add(date);
    		}
            date = date.AddDays(1);
    	}
    		
    	return businessDays;
    }
