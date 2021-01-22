    NameValueCollection nvcData = HttpUtility.ParseQueryString(queryString);
    Dictionary<string, string> dictData = new Dictionary<string, string>(nvcData.Count);
    foreach (string key in nvcData.AllKeys)
    {
        dictData.Add(key, nvcData.Get(key));
    }
