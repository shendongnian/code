    public static string HexValueToStringValue(string hex, int pattern = 196)
    {
        pattern = pattern % 0x100;
        var sb = new StringBuilder(hex.Length / 2);
        for (int i = 0; i < hex.Length; i += 2)
        {
            string h = hex.Substring(i, 2);
            int val = Convert.ToInt32(h, 16);
            char ch = (char)(val ^ pattern);
            sb.Append(ch);
            pattern = (val + 1) % 0x100;
        }
        return sb.ToString();
    }
    public static string StringToHexValue(string str, int pattern = 196)
    {
        pattern = pattern % 0x100;
        var sb = new StringBuilder(str.Length * 2);
        for (int i = 0; i < str.Length; i++)
        {
            char ch = str[i];
            int val = ch ^ pattern;
            string h = val.ToString("X2");
            sb.Append(h);
            pattern = (val + 1) % 0x100;
        }
        return sb.ToString();
    }
