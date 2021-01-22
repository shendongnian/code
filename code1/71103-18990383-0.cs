    private static HashSet<char> ValidChars = new HashSet<char>() { 'a', 'b', 'c', 'A', 'B', 'C', '1', '2', '3', '_' };
    public static string RemoveSpecialCharacters(string str)
    {
        StringBuilder sb = new StringBuilder(str.Length / 2);
        foreach (char c in str)
        {
            if (ValidChars.Contains(c)) sb.Append(c);
        }
        return sb.ToString();
    }
