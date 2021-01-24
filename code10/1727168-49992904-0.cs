    System.DateTime date1 = new System.DateTime(2018, 4, 24, 22, 15, 0);
	System.DateTime date2 = new System.DateTime(2018, 4, 24, 13, 2, 0);
		
	System.TimeSpan diff1 = date2.Subtract(date1);
		
	Console.WriteLine(diff1.TotalHours);
		
	if(diff1.TotalHours >= -24 && diff1.TotalHours <=24)
	{
		Console.WriteLine("Within +/- 24 Hours");
	}
