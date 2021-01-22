    public static string TruncateAtWord(this string input, int length)
    {
    	if (input == null || input.Length < length)
    		return input;
    	int iNextSpace = input.IndexOf(" ", length);
    	return input.Substring(0, (iNextSpace > 0) ? iNextSpace : length).Trim();
    }
