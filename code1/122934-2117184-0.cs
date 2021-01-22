    [StructLayout(LayoutKind.Explicit)]
    public struct SomeStruct
    {
        [FieldOffset(0)]
        public byte b1;
        [FieldOffset(3)]
        public byte b2;
        [FieldOffset(7)]
        public int i1;
        [FieldOffset(12)]
        public int i2;
    }
    
    class Program
    {
        static FieldOffsetAttribute GetFieldOffset(string fieldName)
        {
            return (FieldOffsetAttribute)typeof(SomeStruct)
                .GetField(fieldName)
                .GetCustomAttributes(typeof(FieldOffsetAttribute), false)[0];
        }
    
        static void Main(string[] args)
        {
            var someStruct = new SomeStruct { b1 = 1, b2 = 2, i1 = 3, i2 = 4 };
            
            Console.WriteLine("field b1 offset: {0}", GetFieldOffset("b1").Value);
            Console.WriteLine("field b2 offset: {0}", GetFieldOffset("b2").Value);
            Console.WriteLine("field i1 offset: {0}", GetFieldOffset("i1").Value);
            Console.WriteLine("field i2 offset: {0}", GetFieldOffset("i2").Value);
            
            Console.ReadLine();
        }
    }
