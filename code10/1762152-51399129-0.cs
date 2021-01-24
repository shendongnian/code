    public static long WriteAppend(this FileStream fs, string str, Encoding enc)
    {
        long pos = fs.Length;
        fs.Position = pos;
        byte[] bytes = enc.GetBytes(str);
        fs.Write(bytes, 0, bytes.Length);
        return pos;
    }
    public static long RewriteTruncate(this FileStream fs, long pos, string str, Encoding enc)
    {
        fs.Position = pos;
        byte[] bytes = enc.GetBytes(str);
        fs.Write(bytes, 0, bytes.Length);
        fs.SetLength(pos + bytes.Length);
        return pos;
    }
