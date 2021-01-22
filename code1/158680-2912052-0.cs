    private static Dictionary<string, Regex> regexCache = new Dictionary<string, Regex>();
    public static string RegexReplace(this string value, string pattern, string replacement)
    {
        return RegexReplaceInternal(value, pattern, replacement, RegexOptions.Compiled);
    }
    private static object rriLocker = new object();
    private static string RegexReplaceInternal(string value, string pattern, string replacement, RegexOptions regexOptions)
    {
        bool isInCache;
        lock (rriLocker)
        {
            isInCache = regexCache.ContainsKey(pattern);
        }
        if (isInCache)
        {
            return regexCache[pattern].Replace(value, replacement);
        }
        lock (rriLocker)
        {
            Regex rx = new Regex(pattern, RegexOptions.Compiled);
            regexCache.Add(pattern, rx);
            return rx.Replace(value, replacement);
        }
    }
