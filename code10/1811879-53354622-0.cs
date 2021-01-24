    public static string ReverseWithFor(string s)
    {
        if (string.IsNullOrEmpty(s)) return s;
        char[] a = new char[s.Length];
        for (int i = 0; i < s.Length; i++)
            a[s.Length - 1 - i] = s[i];
        return new string(a);
    }
