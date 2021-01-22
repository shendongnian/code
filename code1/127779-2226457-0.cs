    public static string DictToQueryString(Dictionary<string, string> data)
    {
        string querystring = "";
        foreach (string key in data.Keys)
        {
            string val = data[key];
            querystring += key + "=" + val + "&";
        }
    
        return querystring;
    }
