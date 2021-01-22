            var input = new []
                            {
                                new [] { "[66,X,X]", "[67,X,2]", "[x,x,x]" },
                                new [] { "[5,X,X]", "[8,X,2]", "[x,x,x]" }
                            };
            var query = from l in input
                        select new 
                        {
                         Key = GetNumber(l.ElementAt(0)), 
                         Value = GetNumber(l.ElementAt(1))
                         };
            var dictionary = query.ToDictionary(x => x.Key, x => x.Value);
