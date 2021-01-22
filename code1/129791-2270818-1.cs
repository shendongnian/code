    public static IEnumerable<object>[] Split(this IEnumerable<object> tokens,
                                              TokenType type) {
        var outer = new List<List<object>>();
        var inner = new List<object>();
        var enumerator = tokens.GetEnumerator();
        while (enumerator.MoveNext()) {
            Token token = enumerator.Current as token;
            if (token == null || token.TokenType != type) {
                inner.Add(item);
            }
            else if (inner.Count > 0) {
                outer.Add(inner);
                inner = new List<object>();
            }
        }
        return outer.ToArray();
    }
