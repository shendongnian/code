    private static readonly HashSet<char> Punctuation = new HashSet<char>("*&#...");
    public static bool ContainsOnePunctuationMark(string text)
    {
        bool seenOne = false;
        foreach (char c in text)
        {
            // TODO: Experiment to see whether HashSet is really faster than
            // Array.Contains. If all the punctuation is ASCII, there are other
            // alternatives...
            if (Punctuation.Contains(c))
            {
                if (seenOne)
                {
                    return false; // This is the second punctuation character
                }
                seenOne = true;
            }
        }
        return seenOne;
    }
