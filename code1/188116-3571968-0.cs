    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace UnicodeDecodeConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                char c = '\u73a9';
                char[] chars = {c};
                Encoding encoding = Encoding.BigEndianUnicode;
                byte[] decodeds = encoding.GetBytes(chars);
                StringBuilder stringBuilder = new StringBuilder("U+");
                foreach (byte decoded in decodeds)
                {
                    stringBuilder.Append(decoded.ToString("x2"));
                }
                Console.WriteLine(stringBuilder);
                Console.ReadLine();
            }
        }
    }
