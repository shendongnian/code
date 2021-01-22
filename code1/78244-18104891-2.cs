    public static string EscapeStringValue(string value)
    {
        const char BACK_SLASH = '\\';
        const char SLASH = '/';
        const char DBL_QUOTE = '"';
        var output = new StringBuilder(value.Length);
        foreach (char c in value)
        {
            switch (c)
            {
                case SLASH:
                    output.AppendFormat("{0}{1}", BACK_SLASH, SLASH);
                    break;
                case BACK_SLASH:
                    output.AppendFormat("{0}{0}", BACK_SLASH);
                    break;
                
                case DBL_QUOTE:
                    output.AppendFormat("{0}{1}",BACK_SLASH,DBL_QUOTE);
                    break;
                
                default:
                    output.Append(c);
                    break;
            }
        }
        return output.ToString();
    }
