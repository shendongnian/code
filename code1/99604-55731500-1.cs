    var dateStart = new DateTime(2019,01,10);
    var dateEnd = new DateTime(2019,01,31);
		
	var timeBetween = (dateEnd - dateStart).TotalDays + 1;
	int numberOf7DayWeeks = (int)(timeBetween / 7);
	int numberOfWeekendDays = numberOf7DayWeeks * 2;
	int workingDays =(int)( timeBetween - numberOfWeekendDays);
		
	if(dateStart.DayOfWeek == DayOfWeek.Saturday || dateEnd.DayOfWeek == DayOfWeek.Sunday){
		workingDays -=2;
	}		
	if(dateStart.DayOfWeek == DayOfWeek.Sunday || dateEnd.DayOfWeek == DayOfWeek.Saturday){
		workingDays -=1;
	}
