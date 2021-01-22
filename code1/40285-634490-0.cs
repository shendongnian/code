    public string GetQueryString(params string[] paramName)
    {
        var result = from p in paramName
                     where !String.IsNullOrEmpty(p)
                     select p + ":" + Request.QueryString[p];
        return String.Join(" ", result.ToArray());
    }
