    public List<string> Keyword_Search(HtmlNode nSearch)
    {
        var wordFound = new List<string>();
        // cache inner HTML
        string innerHtml = nSearch.InnerHtml;
        foreach (string currWord in _keywordList)
        {
            bool isMatch = Regex.IsMatch(innerHtml, "\\b" + @currWord + "\\b",
                                                  RegexOptions.IgnoreCase);
            if (isMatch)
            {
                wordFound.Add(currWord);
            }
        }
        return wordFound;
    }
