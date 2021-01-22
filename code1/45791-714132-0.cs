	static void Main(string[] args)
	{
		try
		{
			string sInput;
			// The string to search.
			sInput = "ParameterINeed: 758\r\nParameterCount: 8695\r\nParameterText: 56";
			var regex = new Regex(@"(?<parameter>\w+):\s+(?<value>\d+)", RegexOptions.Singleline);
			var dictionary = new Dictionary<string, string>();
			foreach (Match match in regex.Matches(sInput))
			{
				dictionary.Add(
				match.Groups["parameter"].Value, 
				match.Groups["value"].Value); 
			}
			foreach (KeyValuePair<string, string> item in dictionary)
				Console.WriteLine("key: {0}; value:{1}", item.Key, item.Value);
		}
		finally
		{
			Console.ReadKey();
		}
	}
