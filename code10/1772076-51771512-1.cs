    public static IEnumerable<string> SplitInChunksWithRegex(string s, int size = 2)
    {
        var regex = new Regex($".{{1,{size}}}");
        return regex.Matches(s).Cast<Match>().Select(m => m.Value);
    }
