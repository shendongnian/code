    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Globalization;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input = "FB:77:CB:0B:EC:09{W: 0,623413, X: 0,015374, Y: 0,005306, Z: -0,781723}";
                string pattern = @"W:\s*(?'W'[-+]?\d+,\d+),\s*X:\s*(?'X'[-+]?\d+,\d+),\s*Y:\s*(?'Y'[-+]?\d+,\d+),\s*Z:\s*(?'Z'[-+]?\d+,\d+)";
                CultureInfo info = new CultureInfo("en");
                info.NumberFormat.NumberDecimalSeparator = ",";
                Match match = Regex.Match(input, pattern);
                decimal W = decimal.Parse(match.Groups["W"].Value, info);
                decimal X = decimal.Parse(match.Groups["X"].Value, info);
                decimal Y = decimal.Parse(match.Groups["Y"].Value, info);
                decimal Z = decimal.Parse(match.Groups["Z"].Value, info);
            }
        }
    }
