    /// <summary>
    /// Converts the input string by formatting the words in the dict with their meanings
    /// </summary>
    /// <param name="input">Input string</param>
    /// <param name="dict">Dictionary contains words as keys and meanings as values</param>
    /// <returns>Formatted string</returns>
    public static string FormatForDefns(string input, Dictionary<string,string> dict )
    {
        string formatted = input;
        foreach (KeyValuePair<string, string> kv in dict)
        {
            string definition = "<dfn title=\"" + kv.Value + "\">" + kv.Key + "</dfn>.";
            string pattern = "(?<word>" + kv.Key + ")";
            formatted = Regex.Replace(formatted, pattern, definition, RegexOptions.IgnoreCase);
        }
        return formatted;
    }
