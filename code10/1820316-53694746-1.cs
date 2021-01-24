    void Main()
    {
    	Console.WriteLine(ParseWithDummyIfDateAbsent("15:00", new DateTime(1970, 1, 1)));
    	Console.WriteLine(ParseWithDummyIfDateAbsent("15:00:22", new DateTime(1970, 1, 1)));
    	Console.WriteLine(ParseWithDummyIfDateAbsent("09.12.2018 15:00", new DateTime(1970, 1, 1)));
    }
    
    DateTime ParseWithDummyIfDateAbsent(string input, DateTime dummyDate)
    {
    	
    	if(TimeSpan.TryParse(input, out var timeSpan))
    		input = $"{dummyDate.Date.ToShortDateString()} {input}";
    	return DateTime.Parse(input);
    }
