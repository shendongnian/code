    public static string GetSnippet(string text, string word)
    {
        if (text.IndexOf(word, StringComparison.InvariantCultureIgnoreCase) == -1)
        {
            return "";
        }
    
        var matches = new Regex(@"\b(\S+)\s?", RegexOptions.Singleline | RegexOptions.Compiled).Matches(text);
    
        var p = -1;
        for (var i = 0; i < matches.Count; i++)
        {
            if (matches[i].Value.IndexOf(word, StringComparison.InvariantCultureIgnoreCase) != -1)
            {
                p = i;
                break;
            }
        }
    
        if (p == -1) return "";
        var snippet = "";
        for (var x = Math.Max(p - 10, 0); x < p + 10; x++)
        {
            snippet += matches[x].Value + " ";
        }
        return snippet;
    }
