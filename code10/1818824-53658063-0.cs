    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication89
    {
        class Program
        {
            static void Main(string[] args)
            {
     
                string digits = "8957853759876839473454789595495735984339";
                List<byte> results = Binary.GetBytes(digits);
                //test code
                //for (int i = 0; i < (Math.Pow(2,24)); i++)
                //{
                //    string digits = i.ToString();
                //    Console.WriteLine(i);
                //    List<byte> results = Binary.GetBytes(digits);
                //    long value = results.Select((x, j) => x << (j * 8)).Sum();
                //    if (i != value)
                //    {
                //        int a = 3;
                //    }
                //}
            }
        }
        public class Binary
        {
            public static List<byte> GetBytes(string input)
            {
                List<byte> results = new List<byte>();
                string divisorStr = input;
                
                
                int nibbleCount = 0;
                
                while (divisorStr.Length != 0)
                {
                    int number = 0;
                    string quotentStr = "";
                    byte carry = 0;
                    //divide a string by 16 to get remainders
                    while (divisorStr.Length != 0)
                    {
                        number = (carry * 10) + int.Parse(divisorStr.Substring(0, 1));
                        divisorStr = divisorStr.Substring(1);
                        if (divisorStr.Length == 0) exit = true;
                        int digit = number / 16;
                        if (quotentStr != "" | (digit != 0))
                        {
                            quotentStr += digit.ToString();
                        }
                        carry = (byte)(number % 16);
                    }
                    ///combine the remainders together into an array of bytes
                    if (nibbleCount % 2 == 0)
                    {
                        results.Add(carry);
                    }
                    else
                    {
                        results[results.Count - 1] |= (byte)(carry << 4);
                    }
                    divisorStr = quotentStr;
                    nibbleCount++;
                }
                return results;
            }
        }
    }
