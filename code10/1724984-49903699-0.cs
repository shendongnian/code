    using System;
    using System.Linq;
    namespace Demo
    {
        class Program
        {
            static void Main()
            {
                byte[] data = new byte[16];
                int value = 0x12345678;
                SetBytes(value, data, 1);
                // This prints "0, 0, 0, 0, 78, 56, 34, 12, 0, 0, 0, 0, 0, 0, 0, 0"
                Console.WriteLine(string.Join(", ", data.Select(b => b.ToString("x"))));
            }
            public static unsafe void SetBytes(int value, byte[] output, int index)
            {
                fixed (byte* b = output)
                    *((int*)b + index) = value;
            }
        }
    }
