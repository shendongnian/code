    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApp
    {
        static class Program
        {
            static void Main ()
            {
                var items = new List<List<string>>
                {
                    new List<string> {"A", "B", "C", "D"},
                    new List<string> {"E", "F", "G", "H"},
                    new List<string> {"I", "K", "L", "M"},
                };
    
                var strings = items.SelectMany(x => x).ToList(); //Flatten the array
    
                var result = strings
                    .DifferentCombinations(4)
                    .Select(
                        l => string.Join("", l.ToArray())
                    ).ToList();
    
                result.ForEach(comb => Console.Write($"{comb} "));
                Console.ReadKey();
            }
        }
    
        //Taken from https://stackoverflow.com/a/33336576/7000138
        public static class Ex
        {
            public static IEnumerable<IEnumerable<T>> DifferentCombinations<T> (this IEnumerable<T> elements, int k)
            {
                return k == 0 ? new[] { new T[0] } :
                  elements.SelectMany((e, i) =>
                    elements.Skip(i + 1).DifferentCombinations(k - 1).Select(c => (new[] { e }).Concat(c)));
            }
        }
    }
