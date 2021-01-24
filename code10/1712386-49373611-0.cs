        class Program
    {
        public static Guid LongsToGuid(long l1, long l2)
        {
            var a = (int)l1;
            var b = (short)(l1 >> 32);
            var c = (short)(l1 >> 48);
            var d = (byte)l2;
            var e = (byte)(l2 >> 8);
            var f = (byte)(l2 >> 16);
            var g = (byte)(l2 >> 24);
            var h = (byte)(l2 >> 32);
            var i = (byte)(l2 >> 40);
            var j = (byte)(l2 >> 48);
            var k = (byte)(l2 >> 56);
            return new Guid(a, b, c, d, e, f, g, h, i, j, k);
        }
        public static long BytesToLong(byte[] bytes, int start, int end)
        {
            long toReturn = 0;
            for (var i = start; i < end; i++)
            {
                toReturn |= ((long)bytes[i]) << (8 * i);
            }
            return toReturn;
        }
        static void Main(string[] args)
        {
            var l1 = long.MinValue;
            var l2 = long.MaxValue;
            var guid = LongsToGuid(l1, l2);
            var guidBytes = guid.ToByteArray();
            var readL1 = BytesToLong(guidBytes, 0, 8);
            var readL2 = BytesToLong(guidBytes, 8, 16);
            Console.WriteLine(l1 == readL1);
            Console.WriteLine(l2 == readL2);
            Console.ReadKey();
        }
    }
