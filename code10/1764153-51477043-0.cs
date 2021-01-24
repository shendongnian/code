    private static readonly Dictionary<string, string> LangMap = new Dictionary<string, string>
    {
        { "english", "en" },
        { "german", "de" },
        { "italian", "it" }
    };
    private static readonly string LangString = string.Join("|", LangMap.Keys.Select(x => x).ToArray());
    private static readonly Regex LangPattern = new Regex($@"(?<=https://www\.(.*?)/)({LangString})(?=/.*$)");
    public static string GetSubdomain(string url)
    {
        var match = LangPattern.Match(url);
        return $"http://{LangMap[match.Groups[2].Value]}.{match.Groups[1].Value}/";
    }
