    public string GetQueryString(string string1, string string2, string string3...)
    {
        return GetQueryStringImpl("name1", string1, "name2", string2, "name3", string3, ...);
    }
    
    public string GetQueryStringImpl(params string[] strings)
    {
         for (int i=0; i<strings.Length; i+=2)
         {
              var name = strings[i];
              var s = strings[i+1];
              // check s for null and append to query string
         }
    }
