    private const string _characterPattern = "[^0-9\\p{L}:_ ]";
    private static Regex _regex = new Regex($"({_characterPattern}+):?({_characterPattern}+)");
    ....
    Match match = _regex.Match(line);
    if (match.Success)
    {
        string key = match.Groups[1].Captures[0].Value;
        string value = match.Groups[2].Captures[0].Value;
    }
