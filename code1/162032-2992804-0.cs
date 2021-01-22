    static string RegexLinkify(string text)
    { 
        string pattern = @"(?<alphaCode>[A-Z][A-Z][A-Z]):(?<partNumber>\d{5})";
        Regex r = new Regex(pattern, RegexOptions.Singleline);
        Match matches = r.Match(text);
        string alphaCode = matches.Groups["alphaCode"].Value.ToString();
        string partNumber = matches.Groups["partNumber"].Value.ToString();
        string url = "<a href='www.mysite.com/parts/{0}'>{1}:{0}</a>";
        url = string.Format(url, alphaCode, partNumber);
        return url;
    }
