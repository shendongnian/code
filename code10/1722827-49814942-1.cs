	string input = "24.04.2018 00:00:00";
	
	DateTime d;
	
	if (DateTime.TryParseExact(input, "dd.MM.yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out d))
	{
		var formattedDate = d.ToString("MM/dd/yyyy");
	}
