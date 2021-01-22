    public static class IEnumerable
    {
        static Random rng = new Random((int)DateTime.Now.Ticks);
        public static T RandomElement<T>(this IEnumerable<T> source)
        {
            T current = default(T);
            int c = source.Count();
            int r = rng.Next(c);
            current = source.Skip(r).First();
            return current;
        }
        public static IEnumerable<T> RandomElements<T>(this IEnumerable<T> source, int number)
        {
            return source.OrderBy(r => rng.Next()).Take(number);
        }
    }
