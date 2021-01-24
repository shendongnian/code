    string resultString = null;
    try {
    	Regex regexObj = new Regex(@"([A-Z]{2})-?(\d{10})-?(?:([A-Z]{2,3})|(\d{2}))-?(\d{2})?", RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline);
    	resultString = regexObj.Replace(subjectString, new MatchEvaluator(ComputeReplacement));
    } catch (ArgumentException ex) {
    	// Error handling
    }
    
    public String ComputeReplacement(Match m) {
    	// Vary the replacement text in C# as needed
    	return "$1-$2-$3-$4-$5";
    }
