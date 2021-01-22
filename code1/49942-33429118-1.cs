    public static string CreateQueryString(Dictionary<string, string> parameters)
    {
       return string.Join("&", parameters.Select(kvp => 
          string.Format("{0}={1}", kvp.Key, HttpUtility.UrlEncode(kvp.Value))));
    }
