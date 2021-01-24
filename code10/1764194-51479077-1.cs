    public Dictionary<string, List<string>> CreateFromQuery(string query)
    {
        if (query == null)
        {
            return new Dictionary<string, List<string>>();
        }
    
        var queryDictionary = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(query);
    
        var result = queryDictionary
           .ToDictionary(
               kv => kv.Key, 
               kv => kv.Value.Select(s => s == "\0" ? null : s).ToList()); //There you will have nulls
        return result;
    }
