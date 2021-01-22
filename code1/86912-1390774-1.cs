    private static readonly char[] Punctuation = "*&#...".ToCharArray();
    public static bool ContainsPunctuation(string text)
    {
        return text.IndexOfAny(Punctuation) >= 0;
    }
