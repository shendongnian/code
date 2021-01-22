    public static Dictionary<string, string> ParseQueryString(string queryString)
    {
       var nvc = HttpUtility.ParseQueryString(queryString);
       return nvc.AllKeys.ToDictionary(k => k, k => nvc[k]);
    }
