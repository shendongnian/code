	List<DateTime> dateTimeList = new List<DateTime>();
	DateTime dateNow = DateTime.Now;
		
	// use dateNow.Ticks in the constructor to create a precise, 
    // synchronized DateTime clone
	DateTime date = new DateTime(dateNow.Ticks);
	date = date.AddMinutes(-10);
	while (date < dateNow.AddMinutes(10))
	{
		dateTimeList.Add(date);
		date = date.AddMinutes(1);
	}
	if (dateTimeList.Any(x => x == dateNow))
		Console.WriteLine("date found");
	else
		Console.WriteLine("date Not found");
		
	var format = "ddMMyyyy hh:mm:ss:fffz";
	if (dateTimeList.Any(x => x.ToString(format) == dateNow.ToString(format)))
		Console.WriteLine("date string matched");
	else
		Console.WriteLine("date string didn't match");
