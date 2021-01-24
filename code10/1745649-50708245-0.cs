    public static string WildCardMatch(string wildcardPattern, string input, bool Greedy = true)
    {
        string regexPattern = wildcardPattern.Replace("?", ".").Replace("*", Greedy ? ".*" : ".*?");
        System.Text.RegularExpressions.Match m = System.Text.RegularExpressions.Regex.Match(input, regexPattern, 
            System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        return m.Success ? m.Value : String.Empty;
    }
