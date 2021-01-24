    public static string[] SplitCombineFirst(this string str, params string[] delimiter)
	{
		string[] tokens = str.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
		string first = tokens[0];
		var allCombis = new List<string>{first};
		allCombis.AddRange(tokens.Skip(1).Select(token => $"{first}{delimiter[0]}{token}"));
		return allCombis.ToArray();
	}
