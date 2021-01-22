    public static class Tools
    {
        public static List<TResult> ToList<T, TResult>(
           this IEnumerable<T> input,
                Func<T, TResult> conversion)
        {
            return input.Select(conversion).ToList();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var ret = new[] { "1", "2", "3" }.ToList(i => int.Parse(i));
        }
    }
