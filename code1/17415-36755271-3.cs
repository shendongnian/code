	public static string ResolveName(string name)
	{
		string result = string.Empty;
		foreach(Match match in Regex.Matches(name, "([A-Z]+[a-z]+)"))
		{
			result += match.Value + " ";
		}
		return result.TrimEnd();
	}
