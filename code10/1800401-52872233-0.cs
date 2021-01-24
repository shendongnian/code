    using System.Collections.Generic;
    namespace ConsoleApp42
    {
        class Program
        {
            static void Main (string[] args)
            {
                var array = new int[] { 1, 2, 3, 1, 1, 4, 4, 4, 4, 1, 1, 1 };
                //var array = new string[] { "a", "b", "a", "a" };
                var result = array.MaxCount ();
            }
        }
        public static class Extensions
        {
            public static (long count, T max) MaxCount<T> (this IEnumerable<T> source, IComparer<T> comparer = null)
            {
                if (comparer is null) comparer = Comparer<T>.Default;
                (long count, T max) result = (0, default (T));
                foreach (var element in source)
                {
                    if (result.count == 0) // is first element?
                    {
                        result.max = element;
                        result.count = 1;
                        continue;
                    }
                    int compareResult = comparer.Compare (element, result.max);
                    if (compareResult == 0) // element == max
                    {
                        result.count++;
                    }
                    else if (compareResult > 0) // element > max
                    {
                        result.max = element;
                        result.count = 1;
                    }
                }
                return result;
            }
        }
    }
