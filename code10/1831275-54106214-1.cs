	// this is the time you are going to time out
	DateTime actual = Convert.ToDateTime("12:00 AM").AddDays(1);
	// this is your scheduled out
	DateTime scheduled = Convert.ToDateTime("11:00 PM"); 
	TimeSpan overtime = actual.Subtract(scheduled);
