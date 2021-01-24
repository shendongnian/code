    public static string Simplify2(string str)
    {
        if (string.IsNullOrEmpty(str)) { return str; }
        StringBuilder sb = new StringBuilder();
        char last = str[0];
        sb.Append(last);
        foreach (char c in str)
        {
            if (last != c)
            {
                sb.Append(c);
                last = c;
            }
        }
        return sb.ToString();
    }
