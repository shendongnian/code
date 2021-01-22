    public static class Tools
    {
        public static List<TResult> ToList<T, TResult>(
           this IEnumerable<T> input,
                Func<T, TResult> conversion)
        {
            return input.Select(conversion).ToList();
        }
        public static List<TResult> ToList<T, TResult>(
            this IEnumerable<T> input,
                 Func<T, int, TResult> conversion)
        {
            return input.Select(conversion).ToList();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var input = new[] { "1", "2", "3" };
            var ret = input.ToList(i => int.Parse(i));
            // 1,2,3
            var ret2 = input.ToList((i,j) => int.Parse(i) + j * 10);
            // 1,12,23
        }
    }
