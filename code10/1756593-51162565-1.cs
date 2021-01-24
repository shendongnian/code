    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Program
    {
        public static void Main(string[] args)
        {
            List<long> list = new List<long>(new long[3]);
            list[0] = 0x5445535420;         // AKA header[0] represents the hex integers for Test_  where _ is a space
            list[1] = 0;                    // so the char would be null
            list[2] = 0x4a4153;             // would be JAS
            for (int i = 0; i < list.Count; i++)
            {
                StringBuilder sb = new StringBuilder();
                // Break down each element byte by byte in reverse
                while (list[i] > 0)
                {
                    // Anding against 0xFF to only have the least significant byte to convert into a char
                    sb.Insert(0, Convert.ToChar(list[i] & 0xFF));
                    list[i] >>= 8;  // Remove the least significant byte
                }
                Console.WriteLine(sb);
            }
        }
    }
