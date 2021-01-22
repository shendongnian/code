    static string[] ParseMultiSpacedArguments(string commandLine)
    {
        var isLastCharSpace = false;
        char[] parmChars = commandLine.ToCharArray();
        bool inQuote = false;
        for (int index = 0; index < parmChars.Length; index++)
        {
            if (parmChars[index] == '"')
                inQuote = !inQuote;
            if (!inQuote && parmChars[index] == ' ' && !isLastCharSpace)
                parmChars[index] = '\n';
            isLastCharSpace = parmChars[index] == '\n' || parmChars[index] == ' ';
        }
        return (new string(parmChars)).Split('\n');
    }
