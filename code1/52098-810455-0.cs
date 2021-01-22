    public static bool IsEmptyOrWhitespace(string text)
    {
        // Avoid creating iterator for trivial case
        if (text.Length == 0)
        {
            return true;
        }
        foreach (char c in text)
        {
            // Could use Char.IsWhiteSpace(c) instead
            if (c==' ' || c=='\t' || c=='\r' || c=='\n')
            {
                continue;
            }
            return false;
        }
        return true;
    }
