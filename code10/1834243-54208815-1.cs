    public List<string> GetBetweenTags(string pageContents, string startTag, string endTag)
    {
        Regex rx = new Regex(startTag + "(.*?)" + endTag); //change to "(.*?)>(.*?)"
        MatchCollection col = rx.Matches(value);
        List<string> tags = new List<string>();
        
        foreach(string s in col)
            tags.Add(s);
        return tags;
    }
