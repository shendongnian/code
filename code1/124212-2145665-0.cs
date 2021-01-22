    private static readonly Regex _regex = new Regex(
        @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$", RegexOptions.Compiled);
    public static bool IsAlphaAndNumeric(string s)
    {
        return _regex.IsMatch(s);
    }
