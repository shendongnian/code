    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                string s = "fileone.aspx, filetwo.csv,filethree.exe, filefour.php";
                List<string> extensions = Regex.Matches(s, @"(\.\w+)\s*,")
                    .OfType<Match>().Select(m => m.Groups[1].Value)
                    .ToList();
                extensions.ForEach(i => Console.WriteLine(i));
                Console.ReadLine();
            }
        }
    }
