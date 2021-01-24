    using System;
    using System.Linq;
    using System.Text;
    
    namespace RemovingLastTwoNumber
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Method 1.
                double number = 1.2345678;
                string numberInStringFormat = number.ToString();
                string TargetNumber = numberInStringFormat.Substring(0, numberInStringFormat.Length - 2);
    
                Console.WriteLine(number);
                Console.WriteLine(TargetNumber);
    
                // Method 2.
                string _TargetNumber = Math.Round(number, 5).ToString();
                Console.WriteLine(_TargetNumber);
    
                // Method 3.
                var characters = number.ToString().ToArray();
                var __Characters = characters.Take(7);
                StringBuilder __targetNumber = new StringBuilder();
    
                foreach (var character in __Characters)
                {
                    __targetNumber.Append(character);
                }
    
                Console.WriteLine(__targetNumber);
                
            }
        }
    }
