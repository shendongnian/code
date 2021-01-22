    List<Uri> findUris(string message)
    {
        string anchorPattern = "<a.*href=[\"'](?<url>[^\"]+[.\\s]*)[\"'].*>(?<name>[^<]+[.\\s]*)</a>";
        MatchCollection matches = Regex.Matches(message, anchorPattern, RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Compiled);
        if (matches.Count > 0)
        {
            List<Uri> uris = new List<Uri>();
            foreach (Match m in matches)
            {
                string url = m.Groups["url"].Value;
                Uri testUri = null;
                if (Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out testUri))
                {
                    uris.Add(testUri);
                }
            }
            return uris;
        }
        return null;
    }
