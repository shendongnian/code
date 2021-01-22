    public static string WrapAt(this string str, int WrapPos)
    {
        if (string.IsNullOrEmpty(str))
            throw new ArgumentNullException("str", "Cannot wrap a null string");
        str = str.Replace("\r", "").Replace("\n", "");
    
        if (str.Length <= WrapPos)
            return str;
    
        for (int i = str.Length; i >= 0; i--)
            if (i % WrapPos == 0 && i > 0 && i != str.Length)
                str = str.Insert(i, "\r\n");
        return str;
    }
