    using System;
    using System.Text.RegularExpressions;
    
    public class Program
    {
        public static void Main()
        {
            Regex recognizeText = new Regex(@"search (?<criteria>.+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    
            string input = "search blabla zsdfsdf";
    
            var match = recognizeText.Match(input);
            if (match.Success)
            {
                var searchCriteria = match.Groups["criteria"];
                Console.WriteLine(searchCriteria.Value);
            }
        }
    }
