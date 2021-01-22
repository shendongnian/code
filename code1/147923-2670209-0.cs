    class Program
    {
        static void Main()
        {
            byte[] bytes = StringToByteArray("89504E470D0A1A0A0000000D49484452000000");
        }
    
        public static byte[] StringToByteArray(string hex)
        {
            int length = hex.Length;
            byte[] bytes = new byte[length / 2];
            for (int i = 0; i < length; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
    }
