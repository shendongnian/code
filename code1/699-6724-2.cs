    public static String EncodeCsvLine(params String[] fields)
    {
        StringBuilder line = new StringBuilder();
        for (int i = 0; i < fields.Length; i++)
        {
            if (i > 0) { line.Append(DelimiterChar); }
            String csvField = EncodeCsvField(fields[i]);
            line.Append(csvField);
        }
        return line.ToString();
    }
    static String EncodeCsvField(String field)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(field);
        // Some fields with special characters must be embedded in double quotes
        bool embedInQuotes = false;
        // Embed in quotes to preserve leading/tralining whitespace
        if (sb.Length > 0 && 
            (sb[0] == ' ' || 
             sb[0] == '\t' ||
             sb[sb.Length-1] == ' ' || 
             sb[sb.Length-1] == '\t' )) { embedInQuotes = true; }
        for (int i = 0; i < sb.Length; i++)
        {
            // Embed in quotes to preserve: commas, line-breaks etc.
            if (sb[i] == DelimiterChar || 
                sb[i]=='\r' || 
                sb[i]=='\n' || 
                sb[i] == '"') 
            { 
                embedInQuotes = true;
                break;
            }
        }
        // If the field itself has quotes, they must each be represented 
        // by a pair of consecutive quotes.
        sb.Replace("\"", "\"\"");
        String rv = sb.ToString();
        if (embedInQuotes) { rv = "\"" + rv + "\""; }
        return rv;
    }
