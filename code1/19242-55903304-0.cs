    public static string[] SplitArguments(string commandLine)
    {
        List<string> args         = new List<string>();
        List<char>   currentArg   = new List<char>();
        char?        quoteSection = null; // Keeps track of a quoted section (and the type of quote that was used to open it)
        char[]       quoteChars   = new[] {'\'', '\"'};
        char         previous     = ' '; // Used for escaping double quotes
    
        for (var index = 0; index < commandLine.Length; index++)
        {
            char c = commandLine[index];
            if (quoteChars.Contains(c))
            {
                if (previous == c) // Escape sequence detected
                {
                    previous = ' '; // Prevent re-escaping
                    if (!quoteSection.HasValue)
                    {
                        quoteSection = c; // oops, we ended the quoted section prematurely
                        continue;         // don't add the 2nd quote (un-escape)
                    }
    
                    if (quoteSection.Value == c)
                        quoteSection = null; // appears to be an empty string (not an escape sequence)
                }
                else if (quoteSection.HasValue)
                {
                    if (quoteSection == c)
                        quoteSection = null; // End quoted section
                }
                else
                    quoteSection = c; // Start quoted section
            }
            else if (char.IsWhiteSpace(c))
            {
                if (!quoteSection.HasValue)
                {
                    args.Add(new string(currentArg.ToArray()));
                    currentArg.Clear();
                    previous = c;
                    continue;
                }
            }
    
            currentArg.Add(c);
            previous = c;
        }
    
        if (currentArg.Count > 0)
            args.Add(new string(currentArg.ToArray()));
    
        return args.ToArray();
    }
