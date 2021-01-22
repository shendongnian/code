    public string GetQueryString(string string1, string string2, string string3...)
    {
        return GetQueryStringImpl(string1, string2, string3, ...);
    }
    
    public string GetQueryStringImpl(params string[] strings)
    {
         foreach (string s in strings)
         {
              // check s for null and append to query string
         }
    }
