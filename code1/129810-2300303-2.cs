    public static class TokenExtension
    {
        public static IEnumerable<Token>[] Split(this IEnumerable<Token> tokens)
        {
            return tokens.GroupBy(token => ((Token)token).TokenType).ToArray();
        }
    }
