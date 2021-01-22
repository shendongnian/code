    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    
    class Test
    {
        static void Main(string[] args)
        {
            string original = "abcdefghijkl";
            
            Regex regex = new Regex("a|c|e|g|i|k", RegexOptions.Compiled);
            
            string removedByRegex = regex.Replace(original, "");
            string removedByStringBuilder = new StringBuilder(original)
                .Replace("a", "")
                .Replace("c", "")
                .Replace("e", "")
                .Replace("g", "")
                .Replace("i", "")
                .Replace("k", "")
                .ToString();
            
            Console.WriteLine(removedByRegex);
            Console.WriteLine(removedByStringBuilder);
        }
    }
