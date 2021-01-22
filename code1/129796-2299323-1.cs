        public static IEnumerable<object>[] Split(this  IEnumerable<object> tokens, TokenType type)
        {
            List<List<object>> l = new List<List<object>>();
            l.Add(new List<object>());
            return tokens.Aggregate(l, (c, n) => 
            {
                var t = n as Token;
                if (t != null && t.TokenType == type)
                {
                    t.Add(new List<object>());
                }
                else
                {
                    l.Last().Add(n);
                }
                return t;
            }).ToArray();
        }
