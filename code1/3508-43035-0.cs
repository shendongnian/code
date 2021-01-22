    public static class ForEachExtensions
    {
        public static void ForEachWithIndex<T>(this IEnumerable<T> enumerable, Action<T, int> handler)
        {
            int idx = 0;
            foreach (T item in enumerable)
                handler(item, idx++);
        }
    }
    public class Example
    {
        public static void Main()
        {
            string[] values = new[] { "foo", "bar", "baz" };
            values.ForEachWithIndex((item, idx) => Console.WriteLine("{0}: {1}", idx, item));
        }
    }
