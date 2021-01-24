    var closedOn = new DayOfWeek[] { DayOfWeek.Saturday, DayOfWeek.Sunday };
    var start = new DateTime(2018, 07, 23);
	var numberOfDays = 10;
		
	var businessDays = GetFixedNumberOfBusinessDays(end, numberOfDays, closedOn);
    int actualNumberOfBusinessDays = businessDays.Count(); // 10    
    DateTime endDate = businessDays.Last();                // Friday, August 3, 2018
	
 
 
