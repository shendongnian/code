    // This is the easy way to make your own iterator using the C# syntax
    // It will return sets of separated tokens in a lazy fashion
    // This sample is based on the version provided by @Ants
    public static IEnumerable<IEnumerable<object>> Split(this IEnumerable<object> tokens,
                                              TokenType type) {        
        var current = new List<object>();
        
        foreach (var item in tokens) 
        {
            Token token = item as Token;
            if (token != null && token.TokenType == type) 
            {
                if( current.Count > 0)
                {
                    yield return current;
                    current = new List<object>();
                }
            }
            else 
            {
                current.Add(item);
            }
        }
        if( current.Count > 0)
            yield return current;
    }
