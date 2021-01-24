    using System;
    using System.Text.RegularExpressions;
    
    static class Int32Extensions
    {
        // This doesn't do what you might expect it to!
        public static void Increment(this int x)
        {
            x = x + 1;
        }
    }
    
    class Test
    {
        static void Main()
        {
            string text = @"What is the value of pn in 1 ;/
    This is a test 12./ lop";
            string pattern = @"\d\s?[.,;:]\s?/";
            foreach (Match m in Regex.Matches(text, pattern))
            {
                var position = FindPosition(text, m.Index);
                Console.WriteLine($"{position.line}, {position.column}");
            }
        }
        
        
        static (int line, int column) FindPosition(string text, int index)
        {
             int line = 0;
             int current = 0;
             while (true)
             {
                 int next = text.IndexOf('\n', current);
                 if (next > index || next == -1)
                 {
                     return (line, index - current);
                 }
                 current = next + 1;
                 line++;
             }
        }
    }
