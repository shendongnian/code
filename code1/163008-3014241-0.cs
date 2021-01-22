    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    namespace SO3014119
    {
        class Program
        {
            private static IEnumerable<string> GetStringCombinations(
                string prefix, 
                IEnumerable<string>[] collections, int startWithIndex)
            {
                foreach (var element in collections[startWithIndex])
                {
                    if (startWithIndex < collections.Length - 1)
                    {
                        foreach (var restCombination in
                            GetStringCombinations(prefix + element, collections,
                                startWithIndex + 1))
                        {
                            yield return restCombination;
                        }
                    }
    
                    yield return prefix + element;
                }
            }
    
            public static IEnumerable<string> GetStringCombinations(
                params IEnumerable<string>[] collections)
            {
                while (collections.Length > 0)
                {
                    foreach (var comb in GetStringCombinations("", collections, 0))
                        yield return comb;
                    
                    // "lop off" head and iterate
                    collections = collections.Skip(1).ToArray();
                }
            }
    
            static void Main(string[] args)
            {
                var a = new string[] { "a1", "a2", "a3" };
                var b = new string[] { "b1", "b2", "b3" };
                var c = new string[] { "c1", "c2", "c3" };
    
                foreach (string combination in GetStringCombinations(a, b, c))
                {
                    Console.Out.WriteLine(combination);
                }
            }
        }
    }
