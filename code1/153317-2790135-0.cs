    StringCollection resultList = new StringCollection();
    try {
    	Regex regexObj = new Regex(@"([0-9]+)(?:\.([0-9]{1,2})|)[0-9]*", RegexOptions.Singleline);
    	Match matchResult = regexObj.Match(subjectString);
    	while (matchResult.Success) {
    		resultList.Add(matchResult.Value);
    		matchResult = matchResult.NextMatch();
    	} 
    } catch (ArgumentException ex) {
    	// Syntax error in the regular expression
    }
