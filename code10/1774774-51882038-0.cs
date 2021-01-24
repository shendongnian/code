    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApp1
    {
        class Program
        {
            static string GetText(byte[] value, int startPos)
            {
                if(startPos >= 0 && startPos <= value.Length)
                {
                   return System.Text.Encoding.UTF8.GetString(value).Substring(startPos);
                }
                else
                {
                   return string.Empty;
                }
            }
            static void Main(string[] args)
            {
                byte[] value = new byte[] { 0x41, 0x42, 0x42, 0x42 };
                string result = GetText(value, 1);
                Console.WriteLine(result);
            }
        }
    }
