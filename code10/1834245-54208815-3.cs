    public List<string> GetBetweenTags(string pageContents, string startTag, string endTag)
    {
        Regex rx = new Regex(startTag + "(.*?)" + endTag);
        MatchCollection col = rx.Matches(value);
        List<string> tags = new List<string>();
        
        foreach(Match s in col)
            tags.Add(s.ToString());
        return tags;
    }
