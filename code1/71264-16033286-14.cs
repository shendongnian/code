    public static class ByteArrayExtensions
    {
        public static string ConvertToString(this byte[] bytes)
        {
            if (bytes.Length <= 0)
                return string.Empty;
            char[] chars = new char[bytes.Length / sizeof(char)];
            Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
    }
