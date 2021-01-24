    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main()
        {
            // Input string.
            string input = "<div><p>One</p><p>Two</p><p>Three</p></div>";
    
            // Use named group in regular expression.
            Regex expression = new Regex(@"^<div><p>One</p><p>Two</p>(?<middle>   [<>/\w]+)</div>$");
    
            // See if we matched.
            Match match = expression.Match(input);
            if (match.Success)
            {
                // Get group by name.
                string result = match.Groups["middle"].Value;
                Console.WriteLine("Middle: {0}", result);
            }
            
            // Done
            Console.ReadLine();
        }
    }
