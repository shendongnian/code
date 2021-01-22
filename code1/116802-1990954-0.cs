    static void Main()
    {
        byte[] raw;
        using (MemoryStream ms = new MemoryStream())
        {
            // serialize all
            List<string> data = new List<string> {
               "abc", "def", "ghi", "jkl", "mno", "pqr" };
            foreach (string s in data)
            {
                byte[] buffer = BitConverter.GetBytes(s.Length);
                ms.Write(buffer, 0, buffer.Length);
                buffer = Encoding.UTF8.GetBytes(s);
                ms.Write(buffer, 0, buffer.Length);
            }
            raw = ms.ToArray();
        }
        using (MemoryStream ms = new MemoryStream(raw))
        {
            int offset = 3, len;
            byte[] buffer = new byte[128];
            while (offset-- > 0)
            {
                Read(ms, ref buffer, 4);
                len = BitConverter.ToInt32(buffer, 0);
                ms.Seek(len, SeekOrigin.Current); // assume seekable, but
                                                  // easy to read past if not
            }
            Read(ms, ref buffer, 4);
            len = BitConverter.ToInt32(buffer, 0);
            Read(ms, ref buffer, len);
            string s = Encoding.UTF8.GetString(buffer, 0, len);
        }
    }
    static void Read(Stream stream, ref byte[] buffer, int count)
    {
        if (buffer.Length < count) buffer = new byte[count];
        int offset = 0;
        while (count > 0)
        {
            int bytes = stream.Read(buffer, offset, count);
            if (bytes <= 0) throw new EndOfStreamException();
            offset += bytes;
            count -= bytes;
        }
    }
