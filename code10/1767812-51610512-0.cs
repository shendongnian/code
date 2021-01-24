    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication58
    {
        class Program
        {
            static void Main(string[] args)
            {
                string pattern = @"(?'prefix'[^\w]+)?(?'var1'\w+)(?'operator'\s+(AND|OR)\s+)(?'var2'\w+)(?'suffix'.*)?";
                string input = "(A AND B) OR (C AND D)";
                Match match = null;
                do
                {
                    match = Regex.Match(input, pattern);
                    if (match.Success) input = Regex.Replace(input, pattern, ReplaceVars(match));
                } while (match.Success);
            }
            public static string ReplaceVars(Match m)
            
            {
                return m.Groups["prefix"] + "col LIKE %'" + m.Groups["var1"].Value + "'" + m.Groups["operator"] + "col LIKE %'" + m.Groups["var2"].Value + "'" + m.Groups["suffix"];
            }
        }
    }
