    public static string GetUrlPart(string url)
    {
        Regex regex = new Regex(@"(?:(?:http(s)?:\/\/)|^)(\w+)", RegexOptions.Compiled);
        Match match = regex.Match(url);
        return match.Success ? match.Groups[2].Value : string.Empty;
    }
