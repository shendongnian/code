    public static string Surround(string original, string replacer, string match)
    {
        return Regex.Replace(original, match, replacer, RegexOptions.IgnoreCase);
    }
    Surround("foo bar baz", "<span>$&</span>", "bar");  //call like so
