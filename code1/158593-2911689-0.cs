        public static string getOsFromUserAgent(string userAgent)
    {
        string visitorOS = "other";
        Dictionary<string, string> osNamesAndRegexes = new Dictionary<string, string>();
        osNamesAndRegexes.Add("Windows 98", "(Windows 98)|(Win98)");
        osNamesAndRegexes.Add("Windows XP", "(Windows NT 5.1)|(Windows XP)");
        osNamesAndRegexes.Add("Windows Vista", "(Windows NT 6.0)");
        osNamesAndRegexes.Add("Windows 7", "(Windows NT 7.0)");
        osNamesAndRegexes.Add("Linux", "(Linux)|(X11)");
        osNamesAndRegexes.Add("Mac OS", "(Mac_PowerPC)|(Macintosh)");
        foreach (KeyValuePair<string, string> kvpPair in osNamesAndRegexes)
        {
            if (Regex.IsMatch(userAgent, kvpPair.Value, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                visitorOS = kvpPair.Key;
            }
        }
        return visitorOS;
    }
