    private static readonly char[] whitespace = new char[] { ' ', '\n', '\t', '\r', '\f', '\v' };
    public static string Normalize(string source)
    {
       return String.Join(" ", source.Split(whitespace, StringSplitOptions.RemoveEmptyEntries));
    }
