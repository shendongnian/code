    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    namespace Test
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var text = "https://www.google.com"; // Sample input
                Regex pattern = new Regex(@"[a-z]+(\.[a-z]+)+"); // Regular expression to match the domain
                Match match = pattern.Match(text); // Finds matches
                var domains = match.Value.Split('.'); // Get the match value and split it into an array.
                Console.WriteLine(string.Join(":", domains)); // Sample output
            }
        }
    }
