    /// <summary>
    /// Assigns repeated digits to repeatedDigits, if the digitSequence matches the pattern
    /// </summary>
    /// <returns>true if success, false otherwise</returns>
    public static bool TryGetRepeatedDigits(string digitSequence, out string repeatedDigits)
    {
        repeatedDigits = null;
    
        string pattern = @"^\d*(?<repeat>\d+)\k<repeat>+\d*$";
    
        if (Regex.IsMatch(digitSequence, pattern))
        {
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            repeatedDigits = r.Match(digitSequence).Result("${repeat}");
            return true;
        }
        else
            return false;
    }
