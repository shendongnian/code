    static public string ReplaceCharsWithSpace(this string original, string chars)
    {
        var result = new StringBuilder();
        foreach (var ch in original)
        {
            result.Append(chars.Contains(ch) ? ' ' : ch);
        }
        return result.ToString();
    }
