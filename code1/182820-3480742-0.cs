    private int ParseInput(string input)
    {
        System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(@"\d+");
        string valueString = string.Empty;
        foreach (System.Text.RegularExpressions.Match match in r.Matches(input))
            valueString += match.Value;
        return Convert.ToInt32(valueString);
    }
