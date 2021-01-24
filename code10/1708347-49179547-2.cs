	static public DateTime ParseDateTime(string input)
	{
		DateTime output;
		var ok = DateTime.TryParse(input, out output);
		if (ok) return output;
		return DateTime.Today;
	}
	
	static public TimeSpan ParseTime(string input)
	{
		DateTime output;
		var ok = DateTime.TryParseExact(input, @"h:mm tt", CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out output);
		return output.Subtract(output.Date);
	}
	
	
	public static void Main()
	{
		var dateEntered = @"08/03/2018";
        var timeEntered = @"3:00 am";
		DateTime dateResult = ParseDateTime(dateEntered);
        TimeSpan timeResult = ParseTime(timeEntered);
		DateTime finalResult = dateResult.Add(timeResult);
		Console.WriteLine(finalResult);
    }
