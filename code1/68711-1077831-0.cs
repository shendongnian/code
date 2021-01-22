    /// <summary>
    /// Gets the part of the string after ABC
    /// </summary>
    /// <param name="input">Input string</param>
    /// <param name="output">Contains the string after ABC</param>
    /// <returns>true if success, false otherwise</returns>
    public static bool TryGetStringAfterABC(string input, out string output)
    {
        output = null;
    
        string pattern = "^\\s*ABC(?<rest>.*)";
    
        if (Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase))
        {
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            output = r.Match(input).Result("${rest}");
            return true;
        }
        else
            return false;
    }
