    using System;
    
    using System.Runtime.InteropServices;
    
    
    [StructLayout(LayoutKind.Explicit)]
    struct TestUnion
    {
    
        [FieldOffset(0)]
        public uint Number;
    
        [FieldOffset(0)]
        public ushort Low;
    
        [FieldOffset(2)]
        public ushort High;
    }
    
    
    class MainClass
    {
        public static void Main(string[] args)
        {        
            var x = new TestUnion { Number = 0xABADF00D };
            Console.WriteLine("{0:X} {1:X} {2:X}", x.Number, x.High, x.Low);
    
            x.Low = 0xFACE;
            Console.WriteLine("{0:X} {1:X} {2:X}", x.Number, x.High, x.Low);
    
            x.High = 0xDEAD;
            Console.WriteLine("{0:X} {1:X} {2:X}", x.Number, x.High, x.Low);
        }
    }
