    bool IsMultipleTimes(string word, string input)
    {
        var regex = new Regex(string.Format(@"\b{0}\b", word), 
                              RegexOptions.IgnoreCase);
        return regex.Matches(input).Count > 1;
    }
