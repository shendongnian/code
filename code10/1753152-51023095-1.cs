    public static bool containsString(string word, string input) 
    {
    	string pattern = Regex.Replace(word, ".", ".*$0");
        RegexOptions options = RegexOptions.Multiline;
    
    	return Regex.Matches(input, pattern, options).Count > 0;
    }
    	
    ...
    string input = @"a12tdddgh22i333gs4444e99rt";
    string word = "tiger";
    	
    bool found = containsString(word, input);
    Console.WriteLine($"found: {found}");
