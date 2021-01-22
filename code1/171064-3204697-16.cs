    using System;
    using System.Text.RegularExpression;
    
    public static int ConvertToInt(String input)
    {
    	// Replace everything that is no a digit.
    	String inputCleaned = Regex.Replace(input, "[^0-9]", "");
    	
    	int value = 0;
    	
    	// Tries to parse the int, returns false on failure.
    	if (int.TryParse(inputCleaned, out value))
    	{
    		// The result from parsing can be safely returned.
    		return value;
    	}
    	
    	return 0; // Or any other default value.
    }
