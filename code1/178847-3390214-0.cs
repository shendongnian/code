    private static readonly char[] Delimiters = " ".ToCharArray();
    private static readonly string[] EmptyArray = new string[0];
    
    public static string[] SplitOnMultiSpaces(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return EmptyArray;
        }
        
        return text.Split(Delimiters, StringSplitOptions.RemoveEmptyEntries);
    }
