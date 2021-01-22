    public string RemoveHTMLTags(string HTMLCode)
    {
        string str=System.Text.RegularExpressions.Regex.Replace(HTMLCode, "<[^>]*>", "");
        return str;
    }
