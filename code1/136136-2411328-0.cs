    public static string RemoveStopWords(string phrase, IEnumerable<string> stop)
    {
        var tokens = Tokenize(phrase);
        var filteredTokens = tokens.Where(s => !stop.Contains(s));
        return string.Join(" ", filteredTokens.ToArray());
    }
    public static IEnumerable<string> Tokenize(string phrase)
    {
        return string.Split(phrase, ' ');
        // Or use a regex, such as:
        //    return Regex.Split(phrase, @"\W+");
    }
