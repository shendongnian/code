    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(FILENAME);
                string pattern = @"\[(?'bracketData'[^\]]+)\](?'repeat'[*+])?";
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (line.Length > 0)
                    {
                        string suffix = line.Split(new string[] {"=>"}, StringSplitOptions.None).Select(x => x.Trim()).Last();
                        MatchCollection matches = Regex.Matches(line, pattern);
                        var brackets = matches.Cast<Match>().Select(x => new { bracket = x.Groups["bracketData"].Value, repeat = x.Groups["repeat"].Value }).ToArray();
                        Console.WriteLine("Brackets : '{0}'; Suffix : '{1}'", string.Join(",", brackets.Select(x => "(" + x.bracket + ")" + x.repeat )), suffix);
                    }
                }
                Console.ReadLine();
            }
        }
     
    }
