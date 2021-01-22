    List<Token> tokens = new List<Token>();
            tokens.Add(new Token { Name = "a", TokenType = TokenType.Type1 });
            tokens.Add(new Token { Name = "b", TokenType = TokenType.Type1 });
            tokens.Add(new Token { Name = "c", TokenType = TokenType.Type1 });
            tokens.Add(new Token { Name = "d", TokenType = TokenType.Type2 });
            tokens.Add(new Token { Name = "e", TokenType = TokenType.Type2  });
            tokens.Add(new Token { Name = "f", TokenType = TokenType.Type3 });
            tokens.Add(new Token { Name = "g", TokenType = TokenType.Type3 });
            tokens.Add(new Token { Name = "h", TokenType = TokenType.Type3 });
            tokens.Add(new Token { Name = "i", TokenType = TokenType.Type4 });
            tokens.Add(new Token { Name = "j", TokenType = TokenType.Type4 });
            tokens.Add(new Token { Name = "k", TokenType = TokenType.Type4 });
            tokens.Add(new Token { Name = "l", TokenType = TokenType.Type4 });
            tokens.Add(new Token { Name = "m", TokenType = TokenType.Type5 });
            StringBuilder stringed = new StringBuilder();
            
            foreach (Token token in tokens)
            {
                stringed.Append(token.Name);
                stringed.Append(", ");
            }
            Response.Write(stringed.ToString());
            Response.Write("</br>");
            
            var q = tokens.Split();
            foreach (var list in tokens.Split())
            {
                stringed = new StringBuilder();
                foreach (Token token in list)
                {
                    stringed.Append(token.Name);
                    stringed.Append(", ");
                }
                Response.Write(stringed.ToString());
                Response.Write("</br>");
            }
