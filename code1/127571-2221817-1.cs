            public int GetNumber(string text)
            {
                var exp = new Regex("(\d+)"); // find a sequence of digits could be \d+
                var matches = exp.Matches(text);
    
                if (matches.Count == 1) // if there's one number return that
                {
                    int number =  int.Parse(matches[0].Value);
                    return number
                }
                else if (matches.Count > 1)
                    throw new InvalidOperationException("only one number allowed");
                else
                    return 0;
            }
