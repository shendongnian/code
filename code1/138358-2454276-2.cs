    private static int StringComparer(string x, string y)
    {
        if (!x.AllChar()) return 1;
        if (!y.AllChar()) return -1;
    
        return x.CompareTo(y) * -1;
    }
    public static bool AllChar(this string x)
    {
        char[] chars = x.ToCharArray();
        bool allchar = chars.Any<char>((c) => !char.IsLetter(c));
    
        return !allchar;
    }
 
