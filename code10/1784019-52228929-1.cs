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
                int[] lengths = new int[] { 7, 8 };
                for (int i = 0; i < lengths.Length; i++)
                {
                    string tmp = new System.Text.RegularExpressions.Regex("(\\d{" + lengths[i] + ",})").Match(inputStr.ToString()).ToString();
                    while (tmp.Length >= lengths[i])
                    {
                        retval.Add(tmp.Substring(0, lengths[i]));
                        tmp = tmp.Remove(0, 1);
                    }
                }
                return retval;
            }
        }
    }
