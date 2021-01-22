    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public static class Extensions
    {
        public static IEnumerable<T> Flatten<T>
            (this IEnumerable<IEnumerable<T>> source)
        {
            return source.SelectMany(x => x);
        }
    }
    
    class Test
    {
        static void Main()
        {
            List<List<string>> strings = new List<List<string>>
            {
                new List<string> { "x", "y", "z" },
                new List<string> { "0", "1", "2" }
            };
            
            foreach (string x in strings.Flatten())
            {
                Console.WriteLine(x);
            }
        }
    }
