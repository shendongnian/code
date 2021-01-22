    void Main()
    {
    	string s = nameof(Seasons.Fall);
    	Console.WriteLine($"Fall is valid: {Seasons.IsValid(s)}"); // true
    
    	s = "WrongSeason";
    	Console.WriteLine($"WrongSeason is valid: {Seasons.IsValid(s)}"); // false
    }
