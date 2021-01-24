    string matchPattern = "((?<=,\").*?(?=\",))";
    string input = "something not qualified,\"12\" x 12\" something qualified, becuase it has a comma\",this one is not qualified and needs no fixing a 12\" x 12\",\"8\" X 8\" sign, plain\",one more";
    var newLine = input;
    
    Regex regx = new Regex(matchPattern);
    Regex regxReplace = new Regex(@"(?<=\w)""[^\w|\""]");
    var matches = regx.Matches(input);
    
    foreach (Match matchingString in matches)
    {        
    	
    	var value = matchingString.Value;
    	if (regxReplace.IsMatch(value))
    	{
    		changed = true;
    		var newReplacementString = regxReplace.Replace(value, "\"\" ");
    		newLine = newLine.Replace(matchingString.Value, newReplacementString);
    	}
    }
    
    return newLine;
