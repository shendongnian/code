    public static bool ContainsOnlySymbols(string inputString)
    {
        // Identifiers used are:
        bool containsMore = false;
        // Go through the characters of the input string checking for symbols
        foreach (char character in inputString)
        {
            containsMore = Char.IsSymbol(character) ? false : true;
			if(!containsMore)
				return false;
        }
        // Return the results
        return true;
    }
