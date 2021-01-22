    /// <summary>
    /// Remove HTML from string with Regex.
    /// </summary>
    public static string StripTagsRegex(string source)
    {
	return Regex.Replace(source, "<.*?>", string.Empty);
    }
    /// <summary>
    /// Compiled regular expression for performance.
    /// </summary>
    static Regex _htmlRegex = new Regex("<.*?>", RegexOptions.Compiled);
    /// <summary>
    /// Remove HTML from string with compiled Regex.
    /// </summary>
    public static string StripTagsRegexCompiled(string source)
    {
	return _htmlRegex.Replace(source, string.Empty);
    }
