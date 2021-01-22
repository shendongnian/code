    using System;
    using System.Text.RegularExpressions;
    using MiniBench;
    
    internal class Program
    {
        public static void Main(string[] args)
        {
    
            int size = int.Parse(args[0]);
            int gapBetweenExtraSpaces = int.Parse(args[1]);
            
            char[] chars = new char[size];
            for (int i=0; i < size/2; i += 2)
            {
                // Make sure there actually *is* something to do
                chars[i*2] = (i % gapBetweenExtraSpaces == 1) ? ' ' : 'x';
                chars[i*2 + 1] = ' ';
            }
            // Just to make sure we don't have a \0 at the end
            // for odd sizes
            chars[chars.Length-1] = 'y';
            
            string bigString = new string(chars);
            // Assume that one form works :)
            string normalized = NormalizeWithSplitAndJoin(bigString);
    
            
            var suite = new TestSuite<string, string>("Normalize")
                .Plus(NormalizeWithSplitAndJoin)
                .Plus(NormalizeWithRegex)
                .RunTests(bigString, normalized);
            
            suite.Display(ResultColumns.All, suite.FindBest());
        }
    
        private static readonly Regex MultipleSpaces = 
            new Regex(@" {2,}", RegexOptions.Compiled);
        
        static string NormalizeWithRegex(string input)
        {
            return MultipleSpaces.Replace(input, " ");
        }
        
        // Guessing as the post doesn't specify what to use
        private static readonly char[] Whitespace =
            new char[] { ' ' };
        
        static string NormalizeWithSplitAndJoin(string input)
        {
            string[] split = input.Split
                (Whitespace, StringSplitOptions.RemoveEmptyEntries);
            return string.Join(" ", split);
        }
    }
