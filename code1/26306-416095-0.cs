    IDictionary<string, string> dictionary = GetRealTwoLetterWordDictionary();
    char[] availableChars = new char[] { 'a', 's', 't' };
    string[] combinations = GetAllCombinations(availableChars);
    IList<string> results = new List<string>();
    
    foreach (string combination in combinations)
    {
    	if (dictionary.ContainsKey(combination)))
    	{
    		results.Add(combination);
    	}
    	
    	string reversed = combination.Reverse();
    	
    	if (dictionary.ContainsKey(reversed)))
    	{
    		results.Add(reversed);
    	}
    }
