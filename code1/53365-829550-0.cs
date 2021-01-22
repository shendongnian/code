    public static bool IsSortedNoRepeats(string text)
    {
        if (text.Length == 0)
        {
            return true;
        }
        char current = text[0];
        for (int i=1; i < text.Length; i++)
        {
            char next = text[i];
            if (next <= current)
            {
                return false;
            }
            current = next;
        }
        return true;
    }
