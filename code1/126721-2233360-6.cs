    private static bool IsDangerousExpressionString(string s, int index)
    {
        if ((index + 10) >= s.Length)
        {
            return false;
        }
        if ((s[index + 1] != 'x') && (s[index + 1] != 'X'))
        {
            return false;
        }
        return (string.Compare(s, index + 2, "pression(", 0, 9, true, CultureInfo.InvariantCulture) == 0);
    }
-
    private static bool IsDangerousOnString(string s, int index)
    {
        if ((s[index + 1] != 'n') && (s[index + 1] != 'N'))
        {
            return false;
        }
        if ((index > 0) && IsAtoZ(s[index - 1]))
        {
            return false;
        }
        int length = s.Length;
        index += 2;
        while ((index < length) && IsAtoZ(s[index]))
        {
            index++;
        }
        while ((index < length) && char.IsWhiteSpace(s[index]))
        {
            index++;
        }
        return ((index < length) && (s[index] == '='));
    }
