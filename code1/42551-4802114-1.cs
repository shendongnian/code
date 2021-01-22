    private static string[] Split(string input, char delimiter, char escapeChar, bool removeEmpty)  
        {  
            if (input == null)
            {
                return new string[0];
            }
            char[] specialChars = new char[]{delimiter, escapeChar};
            var tokens = new List<string>();
            var token = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                var c = input[i];
                if (c.Equals(escapeChar))
                {
                    if (i >= input.Length - 1)
                    {
                        throw new ArgumentException("Uncompleted escape sequence has been encountered at the end of the input");
                    }
                    var nextChar = input[i + 1];
                    if (nextChar != escapeChar && nextChar != delimiter)
                    {
                        throw new ArgumentException("Unknown escape sequence has been encountered: " + c + nextChar);
                    }
                    token.Append(nextChar);
                    i++;
                }
                else if (c.Equals(delimiter))
                {
                    if (!removeEmpty || token.Length > 0)
                    {
                        tokens.Add(token.ToString());
                        token.Length = 0;
                    }
                }
                else
                {
                    var index = input.IndexOfAny(specialChars, i);
                    if (index < 0)
                    {
                        token.Append(c);
                    }
                    else
                    {
                        token.Append(input.Substring(i, index - i));
                        i = index - 1;
                    }
                }
            }
            if (!removeEmpty || token.Length > 0)
            {
                tokens.Add(token.ToString());
            } 
            return tokens.ToArray();
        }
