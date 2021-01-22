    private static readonly bool[] BadCharValues;
    static StaticConstructor()
    {
        BadCharValues = new bool[char.MaxValue+1];
        char[] badChars = { '!', '@', '#', '$', '%', '_' };
        foreach (char c in badChars)
            BadCharValues[c] = true;
    }
    public static string CleanString(string str)
    {
        var result = new StringBuilder(str.Length);
        for (int i = 0; i < str.Length; i++)
        {
            if (!BadCharValues[str[i]])
                result.Append(str[i]);
        }
        return result.ToString();
    }
