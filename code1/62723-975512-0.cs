    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    
    class Test
    {
        static void Main(string[] args)
        {
            Check("1234abc", 1234);
            Check("-12", -12);
            Check("123abc456", 123);
        }
        
        static void Check(string text, int expected)
        {
            int actual = ParseInteger(text);
            if (actual != expected)
            {
                Console.WriteLine("Expected {0}; got {1}", expected, actual);
            }
        }
    
        private static readonly Regex LeadingInteger = new Regex(@"^(-?\d+)");
        
        static int ParseInteger(string item)
        {
            Match match = LeadingInteger.Match(item);
            if (!match.Success)
            {
                throw new ArgumentException("Not an integer");
            }
            return int.Parse(match.Value);
        }
    }
