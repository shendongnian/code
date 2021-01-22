	if (DateTime.TryParseExact(date1, formats,
		new CultureInfo("en-US"),
		DateTimeStyles.None,
		out result))
	{
		DateTime startTime = result;
		Console.Write(startTime);
	}
