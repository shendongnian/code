    enum TokenType
    {
        ColumnData,
        Comma,
        LineTerminator
    }
    class Token
    {
        public TokenType Type { get; private set;}
        public string Data { get; private set;}
        public Token(TokenType type)
        {
            Type = type;
        }
        public Token(TokenType type, string data)
        {
            Type = type;
            Data = data;
        }
    }
    private  IEnumerable<Token> GetTokens(TextReader s)
    {
       var builder = new StringBuilder();
       while (s.Peek() >= 0)
       {
           var c = (char)s.Read();
           switch (c)
           {
               case ',':
               {
                   if (builder.Length > 0)
                   {
                       yield return new Token(TokenType.ColumnData, ExtractText(builder));
                   }
                   yield return new Token(TokenType.Comma);
                   break;
               }
               case '\r':
               {
                    var next = s.Peek();
                    if (next == '\n')
                    {
                        s.Read();
                    }
    
                    if (builder.Length > 0)
                    {
                        yield return new Token(TokenType.ColumnData, ExtractText(builder));
                    }
                    yield return new Token(TokenType.LineTerminator);
                    break;
               }
               default:
                   builder.Append(c);
                   break;
           }
       }
       s.Read();
       if (builder.Length > 0)
       {
           yield return new Token(TokenType.ColumnData, ExtractText(builder));
       }
    }
    private string ExtractText(StringBuilder b)
    {
        var ret = b.ToString();
        b.Remove(0, b.Length);
        return ret;
    }
