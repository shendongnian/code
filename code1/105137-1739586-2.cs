    void Deserialize(string input, List<string[]> values)
    {
        MatchCollection matches = Regex.Matches(input, pattern, RegexOptions.SingleLine | RegexOptions.IgnoreCase);
        foreach(Match match in matches)
        {
            if(match.Success)
            {
                if(match.Groups["nested"].Success && !string.IsNullOrEmpty(match.Groups["nested"].Value))
                {
                    Deserialize(match.Groups["nested"].Value, values);
                }
                else
                {
                    values.Add(new string[] {
                        match.Groups["key"].Value,
                        match.Groups["simple"].Value
                    });
                }
            }
        }
    }
