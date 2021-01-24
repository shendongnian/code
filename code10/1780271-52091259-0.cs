    using System;
    using System.Text.RegularExpressions;
    
    namespace myApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input = "Hello, meet me 5/1/2019 at 6:32 PM and then 5/2/2019 7:32 PM bye.";
                Regex word = new Regex(@"(([0-9]{1,2}:[0-9]{1,2}\s[A-Z]{2})|([0-9]{1,2}\/[0-9]{1,2}\/[0-9]{4}))");
                MatchCollection mc = word.Matches(input);
                foreach (Match m in mc)
                {
                    Console.WriteLine(m);
                }
            }
        }
    }
