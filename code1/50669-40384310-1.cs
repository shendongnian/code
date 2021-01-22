    public string From_To(string text, string from, string to)
    {
        if (text == null)
            return null;
        string pattern = @"" + from + ".*?" + to;
        Regex rx = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
        MatchCollection matches = rx.Matches(text);
        return matches.Count <= 0 ? text : matches.Cast<Match>().Where(match => !string.IsNullOrEmpty(match.Value)).Aggregate(text, (current, match) => current.Replace(match.Value, ""));
    }
