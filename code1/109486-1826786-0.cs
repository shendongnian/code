    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static string Switcheroo(string input)
            {
                return System.Text.RegularExpressions.Regex.Replace
                    (input,
                     @"^([^^]+)\^([^^]+)\^(.+)$",
                     "$2^$1^$3",
                     System.Text.RegularExpressions.RegexOptions.Multiline);
            }
    
            static void Main(string[] args)
            {
                string input = "address 1^name 1^notes1\n" +
                         "another address^another name^more notes\n" +
                         "last address^last name^last set of notes";
    
                string output = Switcheroo(input);
                Console.WriteLine(output);
                Console.ReadKey(true);
            }
        }
    }
