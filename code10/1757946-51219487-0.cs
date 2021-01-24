    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var text = "https://www.google.com";
                Regex pattern = new Regex(@"[a-z]+(\.[a-z]+)+");
                Match match = pattern.Match(text);
                var domains = match.Value.Split('.');
                Console.WriteLine(string.Join(":", domains));
            }
        }
    }
