    public static IEnumerable<string> SplitCommandLine(string commandLine)
    {
		bool inQuotes = false;
		bool isEscaping = false;
	
		return commandLine.Split(c => {
			if (c == '\\' && !isEscaping) { isEscaping = true; return false; }
	
			if (c == '\"' && !isEscaping)
				inQuotes = !inQuotes;
	
			isEscaping = false;
	
			return !inQuotes && Char.IsWhiteSpace(c)/*c == ' '*/;
			})
			.Select(arg => arg.Trim().TrimMatchingQuotes('\"').Replace("\\\"", "\""))
			.Where(arg => !string.IsNullOrEmpty(arg));
    }
