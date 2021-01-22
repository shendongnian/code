    public static IEnumerable<String> SplitArguments(string commandLine)
    {
        Char quoteChar = '"';
        Char escapeChar = '\\';
        Boolean insideQuote = false;
        Boolean insideEscape = false;
        StringBuilder currentArg = new StringBuilder();
        // needed to keep "" as argument but drop whitespaces between arguments
        Int32 currentArgCharCount = 0;                  
        for (Int32 i = 0; i < commandLine.Length; i++)
        {
            Char c = commandLine[i];
            if (c == quoteChar)
            {
                currentArgCharCount++;
                if (insideEscape)
                {
                    currentArg.Append(c);       // found \" -> add " to arg
                    insideEscape = false;
                }
                else if (insideQuote)
                {
                    insideQuote = false;        // quote ended
                }
                else
                {
                    insideQuote = true;         // quote started
                }
            }
            else if (c == escapeChar)
            {
                currentArgCharCount++;
                if (insideEscape)   // found \\ -> add \\ (only \" will be ")
                    currentArg.Append(escapeChar + escapeChar);       
                insideEscape = !insideEscape;
            }
            else if (Char.IsWhiteSpace(c))
            {
                if (insideQuote)
                {
                    currentArgCharCount++;
                    currentArg.Append(c);       // append whitespace inside quote
                }
                else
                {
                    if (currentArgCharCount > 0)
                        yield return currentArg.ToString();
                    currentArgCharCount = 0;
                    currentArg.Clear();
                }
            }
            else
            {
                currentArgCharCount++;
                if (insideEscape)
                {
                    // found non-escaping backslash -> add \ (only \" will be ")
                    currentArg.Append(escapeChar);                       
                    currentArgCharCount = 0;
                    insideEscape = false;
                }
                currentArg.Append(c);
            }
        }
        if (currentArgCharCount > 0)
            yield return currentArg.ToString();
    }
