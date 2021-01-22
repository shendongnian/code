        private List<string> parceDelimitedString (string arguments, char delim = ',')
        {
            bool inQuotes = false;
            bool inNonQuotes = false; //used to trim leading WhiteSpace
            
            List<string> strings = new List<string>();
            StringBuilder sb = new StringBuilder();
            foreach (char c in arguments)
            {
                if (c == '\'' || c == '"')
                {
                    if (!inQuotes)
                        inQuotes = true;
                    else
                        inQuotes = false;
                }else if (c == delim)
                {
                    if (!inQuotes)
                    {
                        strings.Add(sb.Replace("'", string.Empty).Replace("\"", string.Empty).ToString());
                        sb.Remove(0, sb.Length);
                        inNonQuotes = false;
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
                else if ( !char.IsWhiteSpace(c) && !inQuotes && !inNonQuotes)  
                {
                    if (!inNonQuotes) inNonQuotes = true;
                    sb.Append(c);
                }
            }
            strings.Add(sb.Replace("'", string.Empty).Replace("\"", string.Empty).ToString());
            return strings;
        }
