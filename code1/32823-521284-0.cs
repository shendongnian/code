    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication9
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input = @"This;is:a.test";
                char sep0 = ';', sep1 = ':', sep2 = '.';
                string pattern = string.Format("[{0}{1}{2}]|[^{0}{1}{2}]+", sep0, sep1, sep2);
                Regex regex = new Regex(pattern);
                MatchCollection matches = regex.Matches(input);
                List<string> parts=new List<string>();
                foreach (Match match in matches)
                {
                    parts.Add(match.ToString());
                }
            }
        }
    }
