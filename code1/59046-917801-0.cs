    using System;
    using System.Text.RegularExpressions;
    
    class Test
    {   
        static void Main(string[] args)
        {
            Parse("000000-00000 Date First text: something1");
            Parse("200000-00000 Time Second text: something2");
            Parse("234222-34332 struc Third text: somthing3");
        }
        
        static readonly Regex Pattern = new Regex
            (@"^\d{6}-\d{5} \w* ([^:]*): ");
        
        static void Parse(string text)
        {
            Console.WriteLine("Input: {0}", text);
            Match match = Pattern.Match(text);
            if (!match.Success)
            {
                Console.WriteLine("No match!");
            }
            else
            {
                Console.WriteLine("Middle bit: {0}", match.Groups[1]);
            }
        }
    }
