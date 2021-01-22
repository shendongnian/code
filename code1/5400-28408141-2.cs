    using System;
    using System.Collections.Generic;
    static class Tool
    {
        public static string DecToHex(int x)
        {
            string result = "";
            while (x != 0)
            {
                if ((x % 16) < 10)
                    result = x % 16 + result;
                else
                {
                    string temp = "";
                    switch (x % 16)
                    {
                        case 10: temp = "A"; break;
                        case 11: temp = "B"; break;
                        case 12: temp = "C"; break;
                        case 13: temp = "D"; break;
                        case 14: temp = "E"; break;
                        case 15: temp = "F"; break;
                    }
                    result = temp + result;
                }
                x /= 16;
            }
            return result;
        }
        public static int HexToDec(string x)
        {
            int result = 0;
            int count = x.Length - 1;
            for (int i = 0; i < x.Length; i++)
            {
                int temp = 0;
                switch (x[i])
                {
                    case 'A': temp = 10; break;
                    case 'B': temp = 11; break;
                    case 'C': temp = 12; break;
                    case 'D': temp = 13; break;
                    case 'E': temp = 14; break;
                    case 'F': temp = 15; break;
                    default: temp = -48 + (int)x[i]; break; // -48 because of ASCII
                }
                result += temp * (int)(Math.Pow(16, count));
                count--;
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Decimal value: ");
            int decNum = int.Parse(Console.ReadLine());
            Console.WriteLine("Dec {0} is hex {1}", decNum, Tool.DecToHex(decNum));
            Console.Write("\nEnter Hexadecimal value: ");
            string hexNum = Console.ReadLine().ToUpper();
            Console.WriteLine("Hex {0} is dec {1}", hexNum, Tool.HexToDec(hexNum));
            Console.ReadKey();
        }
    }
