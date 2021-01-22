    public static Stream ToStream(this string str, Encoding enc = null)
    {
        enc = enc ?? Encoding.UTF8;
        return new MemoryStream(enc.GetBytes(str ?? ""));
    }
