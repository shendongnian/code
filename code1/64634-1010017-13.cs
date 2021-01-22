    public static IEnumerable<string> SplitString(string s, int length)
    {
        var buf = new char[length];
        using (var rdr = new StringReader(s))
        {
            int l;
            l = rdr.ReadBlock(buf, 0, length);
            while (l > 0)
            {
                yield return (new string(buf, 0, l)) + Environment.NewLine;
                l = rdr.ReadBlock(buf, 0, length);
            }
        }
    }
