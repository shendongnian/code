    public string Highlight(string input)
    {
        if (input == string.Empty || searchQuery == string.Empty)
        {
            return input;
        }
        string[] sKeywords = searchQuery.Replace("~",String.Empty).Replace("  "," ").Trim().Split(' ');
        int totalCount = sKeywords.Length + 1;
        string[] sHighlights = new string[totalCount];
        int count = 0;
        input = Regex.Replace(input, Regex.Escape(searchQuery.Trim()), string.Format("~{0}~", count), RegexOptions.IgnoreCase);
        sHighlights[count] = string.Format("<span class=\"highlight\">{0}</span>", searchQuery);
        foreach (string sKeyword in sKeywords.OrderByDescending(s => s.Length))
        {
            count++;
            input = Regex.Replace(input, Regex.Escape(sKeyword), string.Format("~{0}~", count), RegexOptions.IgnoreCase);
            sHighlights[count] = string.Format("<span class=\"highlight\">{0}</span>", sKeyword);
        }
        for (int i = totalCount - 1; i >= 0; i--)
        {
            input = Regex.Replace(input, "\\~" + i + "\\~", sHighlights[i], RegexOptions.IgnoreCase);
        }
        return input;
    }
