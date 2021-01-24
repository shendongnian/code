    public static IEnumerable<byte> HexToByte(this string s, int partLength)
    {
        if (s == null)
            throw new ArgumentNullException("s");
        if (partLength <= 0)
            throw new ArgumentException("Part length has to be positive.", "partLength");
        for (var i = 0; i < s.Length; i += partLength)
            yield return Convert.ToByte(s.Substring(i, Math.Min(partLength, s.Length - i)), 16);
    }
