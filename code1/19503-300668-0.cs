    public static char? GetFirstChar(string str, char[] list)
    {
        foreach (char c in str) if (!list.Contains(c)) return c;
        return null;
    }
