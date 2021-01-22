        public static byte Set(this byte x, byte v)
        {
            return (byte)(x | v);
        }
        public static byte Unset(this byte x, byte v)
        {
            return (byte)(x & ~v);
        }
        static void Main(string[] args)
        {
            byte x = 0;
            x = x.Set(2);
            x = x.Unset(2);
        }
