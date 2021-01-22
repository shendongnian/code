    using System;
    using System.Text.RegularExpressions;
    
    public class RegexExample
    {
        public static void Main()
        {
            var text = "ThisStringHasNoSpacesASCIIButItDoesHaveCapitalsLINQ";
    
            // Use positive lookbehind to locate all upper-case letters
            // that are preceded by a lower-case letter.
            var patternPart1 = "(?<=[a-z])([A-Z])";
            
            // Used positive lookbehind and lookahead to locate all
            // upper-case letters that are preceded by an upper-case
            // letter and followed by a lower-case letter.
            var patternPart2 = "(?<=[A-Z])([A-Z])(?=[a-z])";
    
            var pattern = patternPart1 + "|" + patternPart2;
            var rgx = new Regex(pattern);
            var result = rgx.Replace(text, " $1$2");
            
            Console.WriteLine("Input: [{0}]\nOutput: [{1}]", text, result);
        }
    }
