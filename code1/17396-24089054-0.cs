    using System;
    using System.Text.RegularExpressions;
    
    public class RegexExample
    {
        public static void Main()
        {
            var text = "ThisStringHasNoSpacesButItDoesHaveCapitals";
    
            // Use negative lookbehind to match all capital letters
            // that do not appear at the beginning of the string.
            var pattern = "(?<!^)([A-Z])";
    
            var rgx = new Regex(pattern);
            var result = rgx.Replace(text, " $1");
            Console.WriteLine("Input: [{0}]\nOutput: [{1}]", text, result);
        }
    }
