    using System;
    using System.Runtime.InteropServices;
    namespace Demo
    {
        [StructLayout(LayoutKind.Sequential)]
        unsafe struct ReinterpretableStruct
        {
            public       int    a;         // 0 - 1 - 2 - 3
            public fixed byte   buffer[4]; // 4 - 5 - 6 - 7
            public       double x;         // 8 - 9 - 10 - 11 - 12 - 13 - 14 - 15
        }
        [StructLayout(LayoutKind.Sequential)]
        unsafe struct OtherReinterpretableStruct
        {
            public       ushort a;         // 0 - 1
            public fixed byte   buffer[2]; // 2 - 3
            public       float  y;         // 4 - 5 - 6 - 7
            public       long   w;         // 8 - 9 - 10 - 11 - 12 - 13 - 14 - 15
        }
        class Program
        {
            public static void Main()
            {
                unsafe
                {
                    var a = new ReinterpretableStruct();
                    var b = new OtherReinterpretableStruct();
                    int size1 = *(ushort*) b.buffer;
                    int size2 = *((ushort*) &a) + 1;
                    Console.WriteLine(size1);
                    Console.WriteLine(size2);
                }
            }
        }
    }
