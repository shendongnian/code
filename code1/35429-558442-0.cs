    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace TestRandom
    {
        class Program
    {
        static void Main(string[] args)
        {
            // Just to prepopulate a list.
            var ids = (from n in Enumerable.Range(0, 100)
                       select (long)rand.Next(0, 1000)).ToList();
            // Example usage of the GetRandomSet method.
            foreach(long id in GetRandomSet(ids, 4))
                Console.WriteLine(id);
        }
        // Get count random entries from the list.
        public static IEnumerable<long> GetRandomSet(IList<long> ids, int count)
        {
            // Can't get more than there is in the list.
            if ( count > ids.Count)
                count = ids.Count;
            return RandomIntegers(0, ids.Count)
                .Distinct()
                .Take(count)
                .Select(index => ids[index]);
        }
        private static IEnumerable<int> RandomIntegers(int min, int max)
        {
            while (true)
                yield return rand.Next(min, max);
        }
        private static readonly Random rand = new Random();
    }
