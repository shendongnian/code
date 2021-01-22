    static long ReadOneSrch(Stream haystack, byte[] needle)
    {
        int b;
        long i = 0;
        while ((b = haystack.ReadByte()) != -1)
        {
            if (b == needle[i++])
            {
                if (i == needle.Length)
                    return haystack.Position - needle.Length;
            }
            else
                i = b == needle[0] ? 1 : 0;
        }
        return -1;
    }
