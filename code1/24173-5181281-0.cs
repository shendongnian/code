    public static string UrlFormatParams(this string url, string paramsPattern, params object[] paramsValues)
    {
        string[] s = url.Split(new string[] {"?"}, StringSplitOptions.RemoveEmptyEntries);
        string newQueryString = String.Format(paramsPattern, paramsValues);
        List<string> pairs = new List<string>();
        NameValueCollection urlQueryCol = null;
        NameValueCollection newQueryCol = HttpUtility.ParseQueryString(newQueryString);
        if (1 == s.Length)
        {
            urlQueryCol = new NameValueCollection();
        }
        else
        {
            urlQueryCol = HttpUtility.ParseQueryString(s[1]);
        }
        
        for (int i = 0; i < newQueryCol.Count; i++)
        {
            string key = newQueryCol.AllKeys[i];
            urlQueryCol[key] = newQueryCol[key];
        }
        for (int i = 0; i < urlQueryCol.Count; i++)
        {
            string key = urlQueryCol.AllKeys[i];
            string pair = String.Format("{0}={1}", key, urlQueryCol[key]);
            pairs.Add(pair);
        }
        newQueryString = String.Join("&", pairs.ToArray());
        return String.Format("{0}?{1}", s[0], newQueryString);
    }
