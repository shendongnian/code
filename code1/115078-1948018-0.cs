    public static string Collapse( this string source )
    {
        if (string.IsNullOrEmpty( source ))
        {
            return source;
        }
        StringBuilder builder = new StringBuilder();
        bool inWhiteSpace = false;
        bool sawFirst = false;
        foreach (var c in source)
        {
            if (char.IsWhiteSpace(c))
            {
                inWhiteSpace = true;
            }
            else
            {
                // only output a whitespace if followed by non-whitespace
                // except at the beginning of the string
                if (inWhiteSpace && sawFirst)
                {
                    builder.Append(" ");
                }
                inWhiteSpace = false;
                sawFirst = true;
                builder.Append(c);
            }
        }
        return builder.ToString();
    }
