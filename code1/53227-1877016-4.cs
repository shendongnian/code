    NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
    
    queryString.Add("key1", "value1");
    queryString.Add("key2", "value2");
    
    return queryString.ToString(); // Returns "key1=value1&key2=value2", all URL-encoded
