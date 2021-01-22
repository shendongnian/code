    public static int ToBase10(this string base36)
    {
        if (string.IsNullOrEmpty(base36))
            return 0;
        int value = 0;
        foreach (var c in base36.Trim())
        {
            value = value * 36 + c.ToBase10();
        }
        return value;
    }
    public static int ToBase10(this char c)
    {
        if (c >= '0' && c <= '9')
            return c - '0';
        c = char.ToUpper(c);
        if (c >= 'A' && c <= 'Z')
            return c - 'A' + 10;
        return 0;
    }
