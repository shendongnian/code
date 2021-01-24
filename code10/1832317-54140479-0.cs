    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace Test
    {
        static class ExtraLINQ
        {
            public static IEnumerable<T> SmartConcat<T>(this IEnumerable<T> source, params Func<IEnumerable<T>>[] extras)
            {
                foreach (var entry in source)
                    yield return entry;
    
    
                foreach (var laterEntries in extras)
                {
                    foreach (var laterEntry in laterEntries())
                    {
                        yield return laterEntry;
                    }
                }
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                // Executes both functions
                var first = GetCollectionA().Concat(GetCollectionB()).FirstOrDefault();
                Console.WriteLine(first);
    
                // Executes only the first
                var otherFirst = GetCollectionA().SmartConcat(GetCollectionB).FirstOrDefault();
                Console.WriteLine(otherFirst);
    
                Console.ReadLine();
            }
    
            private static IEnumerable<int> GetCollectionA()
            {
                var results = new int[] { 1, 2, 3 };
                Console.WriteLine("GetBob");
                return results;
            }
    
            private static IEnumerable<int> GetCollectionB()
            {
                var results = new int[] { 4,5,6 };
                Console.WriteLine("GetBob4");
                return results;
            }
    
        }
    }
