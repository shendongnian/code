    public List<string> Keyword_Search(HtmlNode nSearch)
    {
        var wordFound = new List<string>();
        // cache inner HTML
        string innerHtml = nSearch.InnerHtml;
        string pattern = "\\b(?:" + string.Join("|", _keywordList) + ")\\b";
        Regex myRegex = new Regex(pattern, RegexOptions.IgnoreCase);
        MatchCollection myMatches = myRegex.Matches(innerHtml);
        foreach (Match myMatch in myMatches)
        {
            wordFound.Add(myMatch.Value);
        }
        return wordFound;
    }    
