	string positiveTest = "Text 123 and more Text THIS IS MORE TEXT";
	string negativeTest = "this has no matches";
	string matchFullCapWord = @"(\b[A-Z]+\b)"; //See : https://regex101.com/r/H9K4nC/1/
	MatchCollection matches;
	Regex reg = new Regex(matchFullCapWord);
	matches = reg.Matches(positiveTest);
	
	if(matches.Count > 0)
	{
		int splitIndex = matches[0].Index;
		
		string stringStart = positiveTest.Substring(0, splitIndex -1);
		string stringEnd = positiveTest.Substring(splitIndex);
	}
