    MatchCollection AllResults = null;
    try {
    	Regex regexObj = new Regex(@"\w+", RegexOptions.Multiline);
    	AllResults = regexObj.Matches("Here is ""my string""    it has ""six  matches"");
    	if (AllResults.Count > 0) {
    		// Access individual matches using AllResults.Item[]
    	} else {
    		// Match attempt failed
    	} 
    } catch (ArgumentException ex) {
    	// Syntax error in the regular expression
    }
