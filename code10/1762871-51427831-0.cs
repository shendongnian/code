    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication55
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input = "40.5 °C 42.4 °C 39.9 °C 40.0 °C";
                string pattern = "(?'temp'[^ ]+) °C";
                decimal[] temperatures = Regex.Matches(input, pattern).Cast<Match>().Select(x => decimal.Parse(x.Groups["temp"].Value)).ToArray();
            }
        }
    }
