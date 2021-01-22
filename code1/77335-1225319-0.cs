    public static String LimitByteLength(String input, Int32 maxLength)
    {
        return new String(input
            .TakeWhile((c, i) =>
                Encoding.UTF8.GetByteCount(input.Substring(0, i + 1)) <= maxLength)
            .ToArray());
    }
    public static String LimitByteLength2(String input, Int32 maxLength)
    {
        for (Int32 i = input.Length - 1; i >= 0; i--)
        {
            if (Encoding.UTF8.GetByteCount(input.Substring(0, i + 1)) <= maxLength)
            {
                return input.Substring(0, i + 1);
            }
        }
        return String.Empty;
    }
