    using System;
    using System.Collections.Generic;
    class HexadecimalToDecimal
    {
        static Dictionary<char, int> hexdecval = new Dictionary<char, int>{
            {'0', 0},
            {'1', 1},
            {'2', 2},
            {'3', 3},
            {'4', 4},
            {'5', 5},
            {'6', 6},
            {'7', 7},
            {'8', 8},
            {'9', 9},
            {'a', 10},
            {'b', 11},
            {'c', 12},
            {'d', 13},
            {'e', 14},
            {'f', 15},
        };
    
        static decimal HexToDec(string hex)
        {
            decimal result = 0;
            hex = hex.ToLower();
    
            for (int i = 0; i < hex.Length; i++)
            {
                char valAt = hex[hex.Length - 1 - i];
                result += hexdecval[valAt] * (int)Math.Pow(16, i);
            }
    
            return result;
        }
    
        static void Main()
        {
    
            Console.WriteLine("Enter Hexadecimal value");
            string hex = Console.ReadLine().Trim();
    
            //string hex = "29A";
            Console.WriteLine("Hex {0} is dec {1}", hex, HexToDec(hex));
    
            Console.ReadKey();
        }
    }
