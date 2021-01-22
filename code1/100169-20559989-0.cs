    public string Highlight(string input)
    {
        if (input == string.Empty || searchQuery == string.Empty)
        {
            return input;
        }
        string[] sKeywords = searchQuery.Split(' ');
        string[] sHighlights = new string[sKeywords.Length];
        string before = "<span class=\"highlight\">";
        string after = "</span>";
        int count = 0;
        
        foreach (string sKeyword in sKeywords.OrderByDescending(s=>s.Length))
        {
            input = Regex.Replace(input, sKeyword, string.Format("[x{0}x]", count), RegexOptions.IgnoreCase);
            sHighlights[count] = string.Format("{0}{1}{2}", before, sKeyword, after);
            count++;
        }
        for (int i = sKeywords.Length - 1; i >= 0; i--)
        {
            input = Regex.Replace(input, "\\[x" + i + "x\\]", sHighlights[i], RegexOptions.IgnoreCase);
        }
        return input;
    }
