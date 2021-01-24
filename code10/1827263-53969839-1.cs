    var today = DateTime.Now;
	var excludeList = new List<DateRange>()
	{
		new DateRange
		{
			Begin = new DateTime(today.Year,today.Month,today.Day,3,0,0),
			End = new DateTime(today.Year,today.Month,today.Day,3,59,59),
		},
		
		new DateRange
		{
			Begin = new DateTime(today.Year,today.Month,today.Day,7,0,0),
			End = new DateTime(today.Year,today.Month,today.Day,7,59,59),
		},
	};
