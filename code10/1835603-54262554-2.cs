    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    class Program
    {
        static void Main(string[] args)
        {
            string testString1 = "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24";
            string testString2 = "61d2e3f6-bcb7-4cd1-a81e-4f8f497f0da2;0;192.100.0.102:4362;2014-02-14;283;0;354;23;0;;;\"0x8D15A2913C934DE\";Thursday, 19-Jun-14 22:58:10 GMT;";
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 1; i < 1000000; i++)
            {
                Delimit(testString1, ',', 22);
                Delimit(testString2, ';', 6);
            }
            sw.Stop();
            Console.WriteLine($"==>{sw.ElapsedMilliseconds}");
            Console.ReadLine();
        }
        static string Delimit(string stringUnderTest, char delimiter, int skipCount)
        {
            const int SIZE_OF_UNICHAR = 2;
            int i = 0;
            int index = 0;
            char c = Char.MinValue;
            GCHandle handle = GCHandle.Alloc(stringUnderTest, GCHandleType.Pinned);
            try
            {
                IntPtr ptr = handle.AddrOfPinnedObject();
                for (i = 0; i < skipCount; i++)
                    while ((char)Marshal.ReadByte(ptr, index += SIZE_OF_UNICHAR) != delimiter) ;
                i = index;
                while ((c = (char)Marshal.ReadByte(ptr, i += SIZE_OF_UNICHAR)) != delimiter) ;
            }
            finally
            {
                if (handle.IsAllocated)
                    handle.Free();
            }
            
            return stringUnderTest.Substring((index + SIZE_OF_UNICHAR) >> 1, (i - index - SIZE_OF_UNICHAR) >> 1);
        }
    }
