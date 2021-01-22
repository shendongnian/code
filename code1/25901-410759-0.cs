    using System;
    using System.Collections.Generic;
    static class Program { // formatted for space
        // usage
        static void Main() {
            int[] data = { 1, 2, 3, 4, 5, 6 };
            var qry = data.Partition(2);
    
            foreach (var grp in qry) {
                Console.WriteLine("---");
                foreach (var item in grp) {
                    Console.WriteLine(item);
                }
            }
        }
    
        static IEnumerable<IEnumerable<T>> Partition<T>(
                this IEnumerable<T> source, int size) {
    
            int count = 0;
            T[] group = null;
            foreach (T item in source) {
                if (group == null) group = new T[size];
                group[count++] = item;
                if (count == size) {
                    yield return group;
                    group = null;
                    count = 0;
                }
            }
            if (count > 0) {
                Array.Resize(ref group, count);
                yield return group;
            }
        }
    }
