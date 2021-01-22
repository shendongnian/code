    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var input = @"This is just a little test of the memb to see if it gets picked up. 
    Deb of course should also be caught here.";
                var dictionary = new Dictionary<string,string>
                {
                    {"memb", "Member"}
                    ,{"deb","Debut"}
                };
                var regex = "(" + String.Join(")|(", dictionary.Keys.ToArray()) + ")";
                foreach (Match metamatch in Regex.Matches(input
                   , regex  /*@"(memb)|(deb)"*/
                   , RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture))
                { 
                    input = input.Replace(metamatch.Value, dictionary[metamatch.Value.ToLower()]);
                }
                Console.Write (input);
                Console.ReadLine();
            }
        }
    }
