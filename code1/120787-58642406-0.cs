    public static String CommonPrefix(String str, params String[] more)
    {
        var prefixLength = str
                          .TakeWhile((c, i) => more.All(s => i < s.Length && s[i] == c))
                          .Count();
        return str.Substring(0, prefixLength);
    }
