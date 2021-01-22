    public static bool IsSortedNoRepeats(string text)
    {
        for (int i=1; i < text.Length; i++)
        {
            if (text[i] <= text[i-1])
            {
                return false;
            }
        }
        return true;
    }
