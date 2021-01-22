    using System;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string compilationOutput =
                    "Compile complete -- 1 errors, 213 warnings" +
                    "Compile complete -- 2 errors, 213 warnings" +
                    "Compile complete -- 3 errors, 213 warnings" +
                    "Compile complete -- 4 errors, 213 warnings";
    
                string pattern = @"(\d+) error(:?s)?";
    
                MatchCollection results = Regex.Matches(compilationOutput, pattern, RegexOptions.IgnoreCase);
    
                int errors = 0;
                foreach (Match m in results)
                {
                    int error;
                    if (int.TryParse(m.Groups[1].Value, out error))
                    {
                        errors += error;
                    }
                }
            }
        }
    }
