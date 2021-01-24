    public static class MyParsers
    {
        /// <summary>
        /// Parses any whitespace (if any) and returns a resulting string
        /// </summary>
        public readonly static TokenListParser<Tokens, string> OptionalWhitespace =
            from chars in Token.EqualTo(Tokens.Whitespace).Many().OptionalOrDefault()
            select chars == null ? "" : new string(' ', chars.Length);
        /// <summary>
        /// Parses a valid text expression
        /// e.g. "abc", "a.c()", "$c", etc.
        /// </summary>
        public readonly static TokenListParser<Tokens, Node> TextExpression =
            from tokens in
                Token.EqualTo(Tokens.OpenCloseParen)
                .Or(Token.EqualTo(Tokens.Hash))
                .Or(Token.EqualTo(Tokens.Dollar))
                .Or(Token.EqualTo(Tokens.Dot))
                .Or(Token.EqualTo(Tokens.Number))
                .Or(Token.EqualTo(Tokens.String))
                .Or(Token.EqualTo(Tokens.Whitespace))
                .Many()
            // if this side of the pipe is all whitespace, return null
            select (Node) (
                tokens.All(x => x.ToStringValue() == " ") 
                ? null
                : new TextNode {
                    Value = string.Join("", tokens.Select(t => t.ToStringValue())).Trim()
                }
            );
        /// <summary>
        /// Parses a full expression that may contain text expressions or nested sub-expressions
        /// e.g. "(a | b)", "( (a.c() | b) | (123 | c) )", etc.
        /// </summary>
        public readonly static TokenListParser<Tokens, Node> Expression =
            from leadWs in OptionalWhitespace
            from lp in Token.EqualTo(Tokens.LParen)
            from nodes in TextExpression
                .Or(Parse.Ref(() => Expression))
                .ManyDelimitedBy(Token.EqualTo(Tokens.Pipe))
                .OptionalOrDefault()
            from rp in Token.EqualTo(Tokens.RParen)
            from trailWs in OptionalWhitespace
            where nodes.Length > 1 && nodes.Any(node => node != null) // has to have at least two sides and one has to be non-null
            select (Node)new Expression {
                Nodes = nodes.Select(node => node ?? new TextNode { Value = "" }).ToArray()
            };
    }
