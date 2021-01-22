    public static string DictToQueryString(Dictionary<string, string> data)
    {
        StringBuilder queryString = new StringBuilder();
        foreach(var pair in data)
        {
            if (queryString.Length > 0)
                queryString.AppendFormat("&{0}={1}", pair.Key, pair.Value);
            else
                queryString.AppendFormat("{0}={1}", pair.Key, pair.Value);
        }
        return queryString.ToString();
    }
