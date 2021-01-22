    /// <summary>
    /// Reads command line arguments from a single string.
    /// </summary>
    /// <param name="argsString">The string that contains the entire command line.</param>
    /// <returns>An array of the parsed arguments.</returns>
    public string[] ReadArgs(string argsString)
    {
        // Collects the split argument strings
        List<string> args = new List<string>();
        // Builds the current argument
        var currentArg = new StringBuilder();
        // Indicates whether the last character was a backslash escape character
        bool escape = false;
        // Indicates whether we're in a quoted range
        bool inQuote = false;
        // Indicates whether there were quotes in the current arguments
        bool hadQuote = false;
        // Remembers the previous character
        char prevCh = '\0';
        // Iterate all characters from the input string
        for (int i = 0; i < argsString.Length; i++)
        {
            char ch = argsString[i];
            if (ch == '\\' && !escape)
            {
                // Beginning of a backslash-escape sequence
                escape = true;
            }
            else if (ch == '\\' && escape)
            {
                // Double backslash, keep one
                currentArg.Append(ch);
                escape = false;
            }
            else if (ch == '"' && !escape)
            {
                // Toggle quoted range
                inQuote = !inQuote;
                hadQuote = true;
                if (inQuote && prevCh == '"')
                {
                    // Doubled quote within a quoted range is like escaping
                    currentArg.Append(ch);
                }
            }
            else if (ch == '"' && escape)
            {
                // Backslash-escaped quote, keep it
                currentArg.Append(ch);
                escape = false;
            }
            else if (char.IsWhiteSpace(ch) && !inQuote)
            {
                if (escape)
                {
                    // Add pending escape char
                    currentArg.Append('\\');
                    escape = false;
                }
                // Accept empty arguments only if they are quoted
                if (currentArg.Length > 0 || hadQuote)
                {
                    args.Add(currentArg.ToString());
                }
                // Reset for next argument
                currentArg.Clear();
                hadQuote = false;
            }
            else
            {
                if (escape)
                {
                    // Add pending escape char
                    currentArg.Append('\\');
                    escape = false;
                }
                // Copy character from input, no special meaning
                currentArg.Append(ch);
            }
            prevCh = ch;
        }
        // Save last argument
        if (currentArg.Length > 0 || hadQuote)
        {
            args.Add(currentArg.ToString());
        }
        return args.ToArray();
    }
