        public static string Identifier(string name)
        {
            Check.IsNotNullOrWhitespace(name, nameof(name));
            // trim off leading and trailing whitespace
            name = name.Trim();
            // should deal with spaces => camel casing;
            name = name.Dehumanize();
            var sb = new StringBuilder();
            if (!SyntaxFacts.IsIdentifierStartCharacter(name[0]))
            {
                // the first characters 
                sb.Append("_");
            }
            foreach(var ch in name)
            {
                if (SyntaxFacts.IsIdentifierPartCharacter(ch))
                {
                    sb.Append(ch);
                }
            }
            var result = sb.ToString();
            if (SyntaxFacts.GetKeywordKind(result) != SyntaxKind.None)
            {
                result = @"@" + result;
            }
                
            return result;
        }
