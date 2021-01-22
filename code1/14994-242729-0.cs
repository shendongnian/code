    private readonly char[] Delimiters = new char[]{','};
 
    private static string[] SplitAndTrim(string input)
    {
        string[] tokens = input.Split(Delimiters,
                                      StringSplitOptions.RemoveEmptyEntries);
        // Remove leading and trailing whitespace
        for (int i=0; i < tokens.Length; i++)
        {
            tokens[i] = tokens[i].Trim();
        }
        return tokens;
    }
