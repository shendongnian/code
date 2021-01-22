    MatchCollection matches = null;
    try {
    	Regex regexObj = new Regex(@"\[[%\w]+\]");
    	matches = regexObj.Matches(input);
    	if (matches.Count > 0) {
    		// Access individual matches using matches.Item[]
    	} else {
    		// Match attempt failed
    	} 
    } catch (ArgumentException ex) {
    	// Syntax error in the regular expression
    }
