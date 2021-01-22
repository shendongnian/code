    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"(?!^[ ]*$)^\S+$";
            string input = @"
       
                abcd
                ABCD1234
                #$%^&*()_+={}
                abc def
                ABC 123
                ";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
