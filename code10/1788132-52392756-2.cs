    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetSmallestType(100)); // System.SByte
            Console.WriteLine(GetSmallestType(200)); // System.Byte
            Console.WriteLine(GetSmallestType(30_000)); // System.Int16
            Console.WriteLine(GetSmallestType(60_000)); // System.UInt15
            Console.WriteLine(GetSmallestType(100_000)); // System.Int32
            Console.WriteLine(GetSmallestType(4_000_000_000)); // System.UInt23
            Console.WriteLine(GetSmallestType(100_000_000_000)); // System.Int64
            Console.WriteLine(GetSmallestType(20_000_000_000_000_000_000m)); // System.Decimal
        }
        public static Type GetSmallestType<T>(T propertyValue)
            where T : struct
        {
            dynamic value = propertyValue;
            return
                value >= (dynamic)sbyte.MinValue && value <= (dynamic)sbyte.MaxValue ? typeof(sbyte) :
                value >= (dynamic)byte.MinValue && value <= (dynamic)byte.MaxValue ? typeof(byte) :
                value >= (dynamic)short.MinValue && value <= (dynamic)short.MaxValue ? typeof(short) :
                value >= (dynamic)ushort.MinValue && value <= (dynamic)ushort.MaxValue ? typeof(ushort) :
                value >= (dynamic)int.MinValue && value <= (dynamic)int.MaxValue ? typeof(int) :
                value >= (dynamic)uint.MinValue && value <= (dynamic)uint.MaxValue ? typeof(uint) :
                value >= (dynamic)long.MinValue && value <= (dynamic)long.MaxValue ? typeof(long) :
                typeof(decimal);
        }
    }
