    private const string Punctuation = "*&#...";
    public static bool ContainsPunctuation(string text)
    {
        return text.IndexOfAny(Punctuation.ToCharArray()) >= 0;
    }
