    var uniqueLettersExceptCaseAndSymbols = new List<char>();
	var letterDuplicateChecker = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
	foreach (char c in text)
	{
		if(!char.IsLetter(c) || letterDuplicateChecker.Add(c.ToString()))
			uniqueLettersExceptCaseAndSymbols.Add(c);
	}
	string result = String.Join(",", uniqueLettersExceptCaseAndSymbols);
