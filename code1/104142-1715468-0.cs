	public static bool IsMD5(string input)
	{
		if (String.IsNullOrEmpty(input))
		{
			return false;
		}
		return Regex.IsMatch(input, "^[0-9a-fA-F]{32}$", RegexOptions.Compiled);
	}
