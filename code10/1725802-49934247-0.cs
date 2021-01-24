	public static void Main()
	{
		string pattern = @"[A-Z]+\s";
		Regex regex = new Regex(pattern);
		string str = "Text 123 and more Text THIS IS MORE TEXT";
		
		var matches = regex.Matches(str);
		string firstString = str.Substring(0, str.IndexOf(matches[0].ToString()));
		Console.WriteLine(firstString);
		string secondString = "";
		foreach (var match in matches)
		{
			
			if(secondString.Contains(match.ToString()))
			   continue;
			secondString = str.Substring(str.IndexOf(match.ToString()));
			Console.WriteLine(secondString);   
		}
	}
