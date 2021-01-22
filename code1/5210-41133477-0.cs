    private static List<String> Tokenise(string value, char seperator)
    {
        List<string> result = new List<string>();
        value = value.Replace("  ", " ").Replace("  ", " ").Trim();
        StringBuilder sb = new StringBuilder();
        bool insideQuote = false;
        foreach(char c in value.ToCharArray())
        {
            if(c == '"')
            {
                insideQuote = !insideQuote;
            }
            if((c == seperator) && !insideQuote)
            {
                if (sb.ToString().Trim().Length > 0)
                {
                    result.Add(sb.ToString().Trim());
                    sb.Clear();
                }
            }
            else
            {
                sb.Append(c);
            }
        }
        if (sb.ToString().Trim().Length > 0)
        {
            result.Add(sb.ToString().Trim());
        }
    
        return result;
    }
