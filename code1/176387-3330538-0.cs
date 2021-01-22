    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    
    public class Test
    {
        static void Main()
        {
            string[] predefined = { "some", "predefined", "words" };
            string[] products = { ".NET", "C#", "C# (2)" };
            
            IEnumerable<string> escapedKeywords = 
                predefined.Concat(products)
                          .Select(Regex.Escape);
            Regex regex = new Regex("(" + string.Join("|", escapedKeywords) + ")");
            Console.WriteLine(regex);
        }
    }
