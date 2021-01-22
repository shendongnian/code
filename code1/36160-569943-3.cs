    public static string Surround(string original, string replacer, string match)
    {
        return Regex.Replace(original, match, replacer);
    }
    Surround("foo bar baz","<span>$&</span>","bar"); //call like so
