    using System;
    using System.Text.RegularExpressions;
    class Program
    {
        static void Main(string[] args)
        {
            Regex re = new Regex("^(.*?)-");
            Func<String, String> untilSlash = (s) => { return re.Match(s).Groups[1].ToString(); };
            Console.WriteLine(untilSlash("223232-1.jpg"));
            Console.WriteLine(untilSlash("443-2.jpg"));
            Console.WriteLine(untilSlash("34443553-5.jpg"));
            Console.WriteLine(untilSlash("noEnding(will result in empty string)"));
            Console.WriteLine(untilSlash(""));
            // Throws exception: Console.WriteLine(untilSlash(null));
        }
    }
