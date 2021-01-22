    using System;
    using System.Text.RegularExpressions;
    class Program
    {
        public static void Main()
        {
            string input = "Net     Amount";
            string needle = "Net Amount";
            string regex = Regex.Escape(needle).Replace(@"\ ", @"\s*");
            bool isMatch = Regex.IsMatch(input, regex, RegexOptions.IgnoreCase);
            Console.WriteLine("isMatch: {0}", isMatch);
        }
    }
