    using System;
    class Test
    {
        unsafe static void Main()
        {
            int a = 0x12345678;
            short b = *(short*)&a;
            Console.WriteLine(b.ToString("x"));
        }
    }
