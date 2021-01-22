    public static string TruncateAtWord(this string input, int length)
    {
    	if (input == null || input.Length < length)
    		return input;
    	int iNextSpace = input.LastIndexOf(" ", length, StringComparison.Ordinal);
    	return string.Format("{0}...", input.Substring(0, (iNextSpace > 0) ? iNextSpace : length).Trim());
    }
