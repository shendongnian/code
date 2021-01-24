    public static class EnumerableExtensions
    {
        public static async Task<IEnumerable<TResult>> SelectAsync<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, Task<TResult>> asyncSelector)
        {
            var results = new List<TResult>();
            foreach (var item in source)
                results.Add(await asyncSelector(item));
            return results;
        }
    }
