    public static IEnumerable<object>[] Split(this IEnumerable<object> tokens,
                                              TokenType type) {
        var outer = new List<List<object>>();
        var inner = new List<object>();
        foreach (var item in tokens) {
            Token token = item as token;
            if (token != null && token.TokenType == type) {
                outer.Add(inner);
                inner = new List<object>();
                continue;
            }
            inner.Add(item);
        }
        outer.Add(inner);
        return outer.ToArray();
    }
