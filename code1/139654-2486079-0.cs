    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Zip<T>(
            this IEnumerable<IEnumerable<T>> sequences,
            Func<IEnumerable<T>, T> aggregate)
        {
            var enumerators = sequences.Select(s => s.GetEnumerator()).ToArray();
            try
            {
                while (enumerators.All(e => e.MoveNext()))
                {
                    
                    var items = enumerators.Select(e => e.Current);
                    yield return aggregate(items);
                }
            }
            finally
            {
                foreach (var enumerator in enumerators)
                {
                    enumerator.Dispose();
                }
            }
        }
    }
