    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            IEnumerable<int> r = Enumerable.Range(1, 20);
            foreach (int i in r.AllButLast(3))
                Console.WriteLine(i);
            Console.ReadKey();
        }
    }
    public static class LinqExt
    {
        public static IEnumerable<T> AllButLast<T>(this IEnumerable<T> enumerable, int n = 1)
        {
            using (IEnumerator<T> enumerator = enumerable.GetEnumerator())
            {
                Queue<T> queue = new Queue<T>(n);
                for (int i = 0; i < n && enumerator.MoveNext(); i++)
                    queue.Enqueue(enumerator.Current);
                while (enumerator.MoveNext())
                {
                    queue.Enqueue(enumerator.Current);
                    yield return queue.Dequeue();
                }
            }
        }
    }
