    public static IEnumerable<string> GetSubStrings(
       string text,
       string start,
       string end)
    {
        string regex = string.Format("{0}(.*?){1}",
            Regex.Escape(start), 
            Regex.Escape(end));
        return Regex.Matches(text, regex, RegexOptions.Singleline)
            .Cast<Match>()
            .Select(match => match.Groups[1].Value);
    }
