    void Main()
    {
    	Console.WriteLine(ParseWithDummyIfDateAbsent("15:00", new DateTime(1970, 1, 1)));
    	Console.WriteLine(ParseWithDummyIfDateAbsent("09.12.2018 15:00", new DateTime(1970, 1, 1)));
    }
    
    DateTime ParseWithDummyIfDateAbsent(string input, DateTime dummyDate)
    {
    	if(input.Replace(":","").Length == 4)
    		input = $"{dummyDate.Date} {input}";
    	DateTime.TryParse(input, out var result);
    	return result;
    }
