    static class EnumerableExtensions
    {
        public static IEnumerable&lt;T> Flatten&lt;T>(this IEnumerable&lt;IEnumerable&lt;T>> sequence)
        {
            foreach(var child in sequence)
                foreach(var item in child)
                    yield return item;
        }
    }
