        static public List<string> ParseDelimitedString(string value, char delimiter)
        {
            bool inQuotes = false;
            bool inNonQuotes = false;
            bool secondQuote = false;
            char curQuote = '\0';
            List<string> results = new List<string>();
            StringBuilder sb = new StringBuilder();
            foreach (char c in value)
            {
                if (inNonQuotes)
                {
                    // then quotes are just characters
                    if (c == delimiter)
                    {
                        results.Add(sb.ToString());
                        sb.Remove(0, sb.Length);
                        inNonQuotes = false;
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
                else if (inQuotes)
                {
                    // then quotes need to be double escaped
                    if ((c == '\'' && c == curQuote) || (c == '"' && c == curQuote))
                    {
                        if (secondQuote)
                        {
                            secondQuote = false;
                            sb.Append(c);
                        }
                        else
                            secondQuote = true;
                    }
                    else if (secondQuote && c == delimiter)
                    {
                        results.Add(sb.ToString());
                        sb.Remove(0, sb.Length);
                        inQuotes = false;
                    }
                    else if (!secondQuote)
                    {
                        sb.Append(c);
                    }
                    else
                    {
                        // bad,as,"user entered something like"this,poorly escaped,value
                        // just ignore until second delimiter found
                    }
                }
                else
                {
                    // not yet parsing a field
                    if (c == '\'' || c == '"')
                    {
                        curQuote = c;
                        inQuotes = true;
                        inNonQuotes = false;
                        secondQuote = false;
                    }
                    else if (c == delimiter)
                    {
                        // blank field
                        inQuotes = false;
                        inNonQuotes = false;
                        results.Add(string.Empty);
                    }
                    else
                    {
                        inQuotes = false;
                        inNonQuotes = true;
                        sb.Append(c);
                    }
                }
            }
            if (inQuotes || inNonQuotes)
                results.Add(sb.ToString());
            return results;
        }
