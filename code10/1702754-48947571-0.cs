    public class Program
    {
        [StructLayout(LayoutKind.Explicit)]
        struct ValueStruct
        {
            [FieldOffset(0)]
            public byte byte1;
            [FieldOffset(1)]
            public byte byte2;
            [FieldOffset(2)]
            public byte byte3;
            [FieldOffset(3)]
            public byte byte4;
            [FieldOffset(0)]
            public uint uint1;
        }
        static void Main(string[] args)
        {
            var value1 = new ValueStruct() { byte1 = 0x88, byte2 = 0x99, byte3 = 0xAA, byte4 = 0xBB };
            var value2 = new ValueStruct() { byte1 = 0x11, byte2 = 0x22, byte3 = 0x33, byte4 = 0x44 };
            Console.WriteLine(value1.uint1);
            Console.WriteLine(value2.uint1);
            if (value1.uint1 > value2.uint1)
            {
                Console.WriteLine("value1 is greater than value2");
            }
            Console.ReadLine();
        }
    }
