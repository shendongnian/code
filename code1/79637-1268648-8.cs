    private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
    private static bool IsTextAllowed(string text)
    {
        return !_regex.IsMatch(text);
    }
