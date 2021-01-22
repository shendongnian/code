    IEnumerable<char> CharsToTitleCase(string s)
	{
		bool newWord = true;
		foreach(char c in s)
		{
			if(newWord) { yield return Char.ToUpper(c); newWord = false; }
			else yield return Char.ToLower(c);
			if(c==' ') newWord = true;
		}
	}
