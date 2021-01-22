    public static IEnumerable<object>[] Split(this  IEnumerable<object> tokens, TokenType type)
    {
        var indexes = tokens.Select((t, index) => new { token = t, index = index }).OfType<Token>().Where(t => t.token.TokenType == type).Select(t => t.index);
        int prevIndex = 0;
        foreach (int item in indexes)
        {
            yield return tokens.Where((t, index) => (index > prevIndex && index < item));
            prevIndex = item;
        }
    }
