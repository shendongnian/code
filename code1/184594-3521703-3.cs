    public static int GetLastIndex(this byte[] buffer)
    {
        return GetLastIndex(buffer);
    }
    public static int GetLastIndex(this ushort[] buffer)
    {
        return GetLastIndex(buffer);
    }
    public static int GetLastIndex(this uint[] buffer)
    {
        return GetLastIndex(buffer);
    }
    private static int GetLastIndex(Array buffer)
    {
        return buffer.GetUpperBound(0);
    }
