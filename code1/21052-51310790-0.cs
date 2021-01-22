    "SomeBunchOfCamelCase2".FromCamelCaseToSentence == "Some Bunch Of Camel Case 2"
    public static string FromCamelCaseToSentence(this string input) {
    	if(string.IsNullOrEmpty(input)) return input;
    	
    	var sb = new StringBuilder();
    	// start with the first character -- consistent camelcase and pascal case
    	sb.Append(char.ToUpper(input[0]));
    	
    	// march through the rest of it
    	for(var i = 1; i < input.Length; i++) {
    		// any time we hit an uppercase OR number, it's a new word
    		if(char.IsUpper(input[i]) || char.IsDigit(input[i])) sb.Append(' ');
    		// add regularly
    		sb.Append(input[i]);
    	}
    	
    	return sb.ToString();
    }
