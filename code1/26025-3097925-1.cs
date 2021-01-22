    public static string Repeat(this string s, int n)
    {
        return new String(Enumerable.Range(0, n).SelectMany(x => s).ToArray());
    }
    public static string Repeat(this char c, int n)
    {
        return new String(c, n);
    }
