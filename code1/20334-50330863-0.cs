    public static class Utils
    {
        public static byte[] ToBin(this string hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
        public static string ToHex(this byte[] ba)
        {
            return  BitConverter.ToString(ba).Replace("-", "");
        }
    }
