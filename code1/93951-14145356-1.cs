    public static bool IsASCII(this string value)
    {
        // ASCII encoding replaces non-ascii with question marks, so we use UTF8 to see if multi-byte sequences are there
        return Encoding.UTF8.GetByteCount(value) == value.Length;
    }
