    private string keywordPattern(string searchKeyword)
    {
        return @"\b(" + string.Join("|", searchKeyword.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                                      .Select(k => Regex.Escape(k.Trim()))) + @")\b";
    }
    
    private string HighlightSearchKeyWords(string searchKeyword, string text)
    {
        var pattern = keywordPattern(searchKeyword);
        Regex exp = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
        return exp.Replace(text, @"<span class=""search-highlight"">$0</span>");
    }
