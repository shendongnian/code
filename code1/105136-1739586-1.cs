    string pattern = @"(?<key>)[A-Z]+)\s(?<value>({.+?}|[^{},]+))";
    List<string[]> results = new List<string[]>(); //probably not best data structure
    MatchCollection matches = Regex.Matches(input, pattern, RegexOptions.SingleLine | RegexOptions.IgnoreCase);
    foreach(Match match in matches)
    {
        if(match.Success)
        {
            results.Add(new string[] {
                match.Groups["key"].Value,
                match.Groups["value"].Value
            });
        }
    }
