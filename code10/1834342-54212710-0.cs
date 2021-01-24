    var threshold = 15; //minutes
	var dt = DateTime.Now.AddMinutes(-20);
	//var dt = DateTime.Now;
	DateTime resultDt;
	
	DateTime thUp = dt.AddMinutes(15);
	DateTime thDown = dt.AddMinutes(-15);
	
	if (thUp.Hour != dt.Hour)
		resultDt = new DateTime(dt.Year, dt.Month, dt.Day, thUp.Hour, 0, 0);
	else if (thDown.Hour != dt.Hour)
		resultDt = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, 0, 0);
	else 
		resultDt = dt;
