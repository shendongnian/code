    using System;
    using System.Collections.Generic;
    public class Program
    {
        static List<string> _zipCodes;
    
        static Program()
        {
            _zipCodes = new List<string>() { "80205", "80225", "80210" };
        }
    
        static void Main(string[] args)
        {
            string userZip = string.Empty;
    
            do
            {
                Console.WriteLine("enter a 5 digit zip code to see if it is supported in our area.");
                Console.WriteLine();
                Console.WriteLine("Enter a -1 to exit the program");
                userZip = Console.ReadLine();
    
                if (_zipCodes.Contains(userZip))//<---------------THAT WAY
                {
                     Console.WriteLine("We support zip code {0}", userZip); ;
                }
                else
                {
                    Console.WriteLine("We do not support zip code {0}", userZip);
                }
    
            } while (userZip != "-1");
    
        }
    }
