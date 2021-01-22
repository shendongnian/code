    protected string CustomResolveURL(object obj)
    {
        string result = string.empty;
        string url = (string)obj
        if(!string.IsNullOrEmpty(url))
        {
            result = ResolveUrl("~/" + url);
        }
        return result;
    }
