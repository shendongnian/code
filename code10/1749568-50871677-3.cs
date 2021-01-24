    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    namespace Demo
    {
        [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 4)]
        public struct Mask32
        {
            [FieldOffset(3)]
            public byte Byte1;
            [FieldOffset(2)]
            public ushort UShort1;
            [FieldOffset(2)]
            public byte Byte2;
            [FieldOffset(1)]
            public byte Byte3;
            [FieldOffset(0)]
            public ushort UShort2;
            [FieldOffset(0)]
            public byte Byte4;
        }
        public static unsafe class Program
        {
            static int count = 50000000;
            public static int ViaStructPointer()
            {
                int total = 0;
                for (int i = 0; i < count; i++)
                {
                    var s = (Mask32*)&i;
                    total += s->Byte1;
                }
                return total;
            }
            public static int ViaUnsafeAs()
            {
                int total = 0;
                for (int i = 0; i < count; i++)
                {
                    var m = Unsafe.As<int, Mask32>(ref i);
                    total += m.Byte1;
                }
                return total;
            }
            public static void Main(string[] args)
            {
                var sw = new Stopwatch();
                sw.Restart();
                ViaStructPointer();
                Console.WriteLine("ViaStructPointer took " + sw.Elapsed);
                sw.Restart();
                ViaUnsafeAs();
                Console.WriteLine("ViaUnsafeAs took " + sw.Elapsed);
            }
        }
    }
