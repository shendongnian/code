    static void Main(string[] args)
    {
        string info = "ZipEntry: testfile.txt\n   Version Made By: 45\n Needed to extract: 45\n" +
                "         File type: binary\n       Compression: Deflate\n        " +
                "Compressed: 0x35556371\n      Uncompressed: 0x1D626FBDB\n      ...";
        ReadOnlySpan<char> span = info.AsSpan();
        ReadOnlySpan<char> compression = "Compression: ".AsSpan();
        int startIndex = span.IndexOf(compression);
        if (startIndex != -1)
        {
            ReadOnlySpan<char> deflate = span.Slice(startIndex + compression.Length);
            int endIndex = deflate.IndexOf('\n');
            if (endIndex != -1)
            {
                string s1 = deflate.Slice(0, endIndex).ToString();
            }
        }
    }
