    // No need to create a new array each time
    private static readonly char[] NewLineChars = Environment.NewLine.ToCharArray();
    public static string TrimNewLines(string text)
    {
        return text.TrimEnd(NewLineChars);
    }
