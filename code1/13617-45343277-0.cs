    public static class StreamExtensions
    {
        public static byte[] ToByteArray(this Stream stream)
        {
            var bytes = new List<byte>();
            int b;
            while ((b = stream.ReadByte()) != -1)
                bytes.Add((byte)b);
            return bytes.ToArray();
        }
    }
