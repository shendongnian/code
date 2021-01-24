    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        public static void Main()        
        {
            string text = "I start with 5 and take away 2.52 to get 2.48 as a result";
            Regex regex = new Regex(@"\d+(\.\d+)?");
            var matches = regex.Matches(text);
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
