    // Fixed version of GetBits, with padding.
    public static string GetBits(string input)
    {
        StringBuilder sb = new StringBuilder();
        foreach (byte b in Encoding.Unicode.GetBytes(input))
        {
            string lowBits = Convert.ToString(b, 2);
            string eightBits = lowBits.PadLeft(8, '0');
            sb.Append(eightBits);
        }
        return sb.ToString();
    }
    public static string UnicodeBitsToString(string input)
    {
        return Encoding.Unicode.GetString(ParseHex(input));
    }
    
    public static byte[] ParseHex(string input)
    {
        byte[] ret = new byte[input.Length/8];
        for (int i=0; i < input.Length; i += 8)
        {
            ret[i/8] = Convert.ToByte(input.Substring(i, 8), 2);
        }
        return ret;
    }
