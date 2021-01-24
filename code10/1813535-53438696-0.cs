    public static void Read(FileInfo path)
    {
        using (FileStream filestream = path.OpenRead())
        {
            using (var d = new GZipStream(filestream, CompressionMode.Decompress))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    d.CopyTo(m);
                    int position = 0;
                    ReadOnlySpan<byte> stream = new ReadOnlySpan<byte>(m.GetBuffer()).Slice(0, (int)m.Length);
                    while (position != stream.Length)
                    {
                        UInt32 value = stream.ReadUInt32(position);
                        position += 4;
                    }
                }
            }
        }
    }
    public static class BinaryReaderBigEndian
    {
        public static UInt32 ReadUInt32(this ReadOnlySpan<byte> stream, int start)
        {
            UInt32 res = 0;
            for (int i = 0; i < 4; i++)
                {
                    res = (res << 8) | (((UInt32)stream[start + i]) & 0xff);
            }
            return res;
        }
    }
