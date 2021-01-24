    using System;
    using System.Runtime.InteropServices;
    class Program
    {
        static void Main(string[] args)
        {
            string testString1 = "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24";
            string testString2 = "61d2e3f6-bcb7-4cd1-a81e-4f8f497f0da2;0;192.100.0.102:4362;2014-02-14;283;0;354;23;0;;;\"0x8D15A2913C934DE\";Thursday, 19-Jun-14 22:58:10 GMT;";
            Delimit(testString1, ',', 22);
            Delimit(testString2, ';', 7);
            Console.ReadLine();
        }
        static void Delimit(string stringUnderTest, char delimiter, int skipCount)
        {
            int i = 0;
            char c = Char.MinValue;
            for (int index = 0; index < skipCount; index++)
                while ((char)Marshal.ReadByte(stringUnderTest, i++) != delimiter);
            while ((c = (char)Marshal.ReadByte(stringUnderTest, i++)) != delimiter) { Console.Write(c); }
            Console.WriteLine();
        }
    }
