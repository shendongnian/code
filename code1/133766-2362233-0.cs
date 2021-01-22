    DateTime date;
    if(DateTime.TryParseExact("Mar10", "MMMdd", new CultureInfo("en-US"), DateTimeStyles.None, out date))
    {
    	Console.WriteLine(date.Month);
    	Console.WriteLine(date.Day);
    }
