    public static byte[] ConvertToByteArray(this string s)
    {
        if (s.StartsWith("0x"))
        {
            var numericValue = ulong.Parse(s);
            return BitConverter.GetBytes(numericValue);
        }
        else
        {
            return s.Split('-').Select(b => Convert.ToByte(b, 16)).ToArray();
        }
    }
