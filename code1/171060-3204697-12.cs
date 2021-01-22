    using System;
    using System.Text.RegularExpression;
    
    public static int ConvertToInt(String input)
    {
    	// Matches the first numebr with or without leading minus.
    	Match match = Regex.Match(input, "-?[0-9]+");
    	
    	if (match.Success)
    	{
    		// No need to TryParse here, the match has to be at least
    		// a 1-digit number.
    		return int.Parse(match.Value);
    	}
    	
    	return 0; // Or any other default value.
    }
