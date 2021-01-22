    int? parseLeadingInt(string input)
    {
        int result = 0;
        Match match = Regex.Match(input, "^[ \t]*\\d+");
        if (match.Success && int.TryParse(match.Value, out result))
        {
            return result;
        }
        return null;
    }
