	// Returns a list of the dates of the Business Days from the given start with the given number of days
	public static IEnumerable<DateTime> GetFixedNumberOfBusinessDays(DateTime startDate, int numberOfBusinessDays, DayOfWeek[] closedOn) {
        if (numberOfBusinessDays < 0) {
		    throw new ArgumentException("numberOfBusinessDays must be zero or positive.");	
		}
		
		var businessDays = new List<DateTime>();
		var date = startDate;
		
		while (businessDays.Count() < numberOfBusinessDays) {
			if (!closedOn.Contains(date.DayOfWeek)) {
				businessDays.Add(date);
			}
            date = date.AddDays(1);
		}
		
		return businessDays;
	}
