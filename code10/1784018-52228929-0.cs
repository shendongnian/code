    using System;
    using System.Collections.Generic;
    
    namespace _52228638_ExtractAllPossibleMatches
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                string inputStr = "asd123456789bbaasd";
                foreach (string item in GetTheMatches(inputStr))
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
            }
    
            private static List<string> GetTheMatches(string inputStr)
            {
                List<string> retval = new List<string>();
                string tmp = new System.Text.RegularExpressions.Regex("(\\d{7,})").Match(inputStr.ToString()).ToString();
                while (tmp.Length >= 7)
                {
                    retval.Add(tmp.Substring(0,7));
                    tmp = tmp.Remove(0, 1);
                }
                tmp = new System.Text.RegularExpressions.Regex("(\\d{8,})").Match(inputStr.ToString()).ToString();
                while (tmp.Length >= 8)
                {
                    retval.Add(tmp.Substring(0, 8));
                    tmp = tmp.Remove(0, 1);
                }
                return retval;
            }
        }
    }
