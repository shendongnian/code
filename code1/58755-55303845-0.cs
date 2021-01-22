    public static string ToUpperEveryWord(this string s)
    {
        // Check for empty string.  
        if (string.IsNullOrEmpty(s))
        {
            return string.Empty;
        }
        var words = s.Split(' ');
        var t = "";
        foreach (var word in words)
        {
            t += char.ToUpper(word[0]) + word.Substring(1) + ' ';
        }
        return t.Trim();
    }
