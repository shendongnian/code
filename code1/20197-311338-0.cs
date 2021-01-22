    public static ByteExtensions
    {
        public static string ToHexString(this byte[] value)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
            {
                hex.AppendFormat("{0:x2}", b)
            }
            return hex.ToString()
        }
    }
