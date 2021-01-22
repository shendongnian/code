    private static readonly HashSet<char> badChars = 
        new HashSet<char> { '!', '@', '#', '$', '%', '_' };
    public static string CleanString(this string str)
    {
        var result = new StringBuilder(str.Length);
        for (int i = 0; i < result.Length; i++)
        {
            if (!badChars.Contains(str[i]))
                result.Append(str[i]);
        }
        return result.ToString();
    }
