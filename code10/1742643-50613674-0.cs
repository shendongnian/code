    var dateString = "5/29/2018 | 1:21:42 PM"; // Time-zone stripped out
	if (DateTime.TryParseExact(dateString,
							   "M/d/yyyy | h:m:s tt",
							   CultureInfo.InvariantCulture,
							   DateTimeStyles.None,
							   out var theDate))
	{
		Console.WriteLine(theDate);
	}
	else
	{
		Console.WriteLine("Unable to parse date");
	}
