    public static byte[] StrToByteArray(this string s)
    {
        List<byte> value = new List<byte>();
        foreach (char c in s.ToCharArray())
            value.Add(c.ToByte());
        return value.ToArray();
    }
