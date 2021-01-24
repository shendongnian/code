    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                string input = File.ReadAllText(FILENAME);
                string pattern = @"^(?'date'\[[^\]]+)\]\s+-\s+(?'type'[^\s]+)\s+-\s+\[(?'message'[^\[]*)";
                MatchCollection matches = Regex.Matches(input, pattern, RegexOptions.Multiline);
                foreach (Match match in matches)
                {
                    Console.WriteLine("Date : '{0}', Type : '{1}', Error Number = '{2}', Message = '[{3}'",
                       match.Groups["date"], match.Groups["type"], match.Groups["errNum"], match.Groups["message"]);
                }
                Console.ReadLine();
            }
        }
    }
