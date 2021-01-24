	public static void Main()
	{
		var strings = new[] {"2011 Trieste MED clean/crude/crude",
							 "2013 Trieste fo/crude/crude",
							 "2013 Ningbo East Pacific cca/cf/ce",
							 "2014 Agioi theodoroi MED cde/fo/ce"};
		
		foreach (var s in strings)
			Console.WriteLine(GetName(s));
	}
	
	public static string GetName(string s)
	{
		var allWords = s.Split(' ');
		var nameWords = allWords.Skip(1).Take(allWords.Length - 2);
		return string.Join(" ", nameWords);
	}
