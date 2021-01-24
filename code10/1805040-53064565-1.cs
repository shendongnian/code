    public string ReplacePattern(string input)
    {
        var match = Regex.Match(input, @"([A-Z])(\d{3})(\d{4})");
        if(match.Groups.Count == 4) // The first group is always the input
        {
            return String.Format("{0}-{1}-{2}", match.Groups.Skip(1).Take(3).ToArray());
        }
        return "";
    }
