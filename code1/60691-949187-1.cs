    /// <summary>
    /// Use of named backrefence 'roundedDigit' and word boundary '\b' for ease of
    /// understanding
    /// Adds the rounded percents to the roundedPercents list
    /// Will work for any percent value
    /// Will work for any number of percent values in the string
    /// Will also give those numbers that are not in percentage (decimal) format
    /// </summary>
    /// <returns>true if success, false otherwise</returns>
    public static bool TryGetRoundedPercents(string digitSequence, out List<string> roundedPercents)
    {
        roundedPercents = null;
        string pattern = @"(?<roundedDigit>\b\d{1,3})(\.\d{1,2}){0,1}\b";
    
        if (Regex.IsMatch(digitSequence, pattern))
        {
            roundedPercents = new List<string>();
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.ExplicitCapture);
           
            for (Match m = r.Match(digitSequence); m.Success; m = m.NextMatch())
                roundedPercents.Add(m.Groups["roundedDigit"].Value);
           
            return true;
        }
        else
            return false;
    }
