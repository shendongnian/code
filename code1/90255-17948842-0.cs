    public static string FormatSortCode(string sortCode)
    {
        return ChunkString(sortCode, 2, "-");
    }
    public static string FormatIBAN(string iban)
    {
        return ChunkString(iban, 4, "&nbsp;&nbsp;");
    }
    private static string ChunkString(string str, int chunkSize, string separator)
    {
        var b = new StringBuilder();
        var stringLength = str.Length;
        for (var i = 0; i < stringLength; i += chunkSize)
        {
            if (i + chunkSize > stringLength) chunkSize = stringLength - i;
            b.Append(str.Substring(i, chunkSize));
            if (i+chunkSize != stringLength)
                b.Append(separator);
        }
        return b.ToString();
    }
