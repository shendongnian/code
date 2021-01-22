    using System;
    using System.Collections.Generic;
    static class Program {
        static void Main() {
            int[] data = { 1, 2, 3, 4, 5, 6 };
    
            int lastOdd = SequenceUtil.Last<int>(
                data, delegate(int i) { return (i % 2) == 1; });
        }    
    }
    static class SequenceUtil {
        public static T Last<T>(IEnumerable<T> data, Predicate<T> predicate) {
            T last = default(T);
            foreach (T item in data) {
                if (predicate(item)) last = item;
            }
            return last;
        }
    }
