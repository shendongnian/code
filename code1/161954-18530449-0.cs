    private static byte[] GetBytes(string bitString)
    {
        byte[] result = Enumerable.Range(0, bitString.Length / 8).
            Select(pos => Convert.ToByte(
                bitString.Substring(pos * 8, 8),
                2)
            ).ToArray();
        List<byte> mahByteArray = new List<byte>();
        for (int i = result.Length - 1; i >= 0; i--)
        {
            mahByteArray.Add(result[i]);
        }
        return mahByteArray.ToArray();
    }
    private static String ToBitString(BitArray bits)
    {
        var sb = new StringBuilder();
        for (int i = bits.Count - 1; i >= 0; i--)
        {
            char c = bits[i] ? '1' : '0';
            sb.Append(c);
        }
        return sb.ToString();
    }
