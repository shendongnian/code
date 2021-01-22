    public static class PositionsExtension
    {
        public static Int32 Position<TSource>(this IEnumerable<TSource> source,
                                              Func<TSource, bool> predicate)
        {
            return Positions<TSource>(source, predicate).FirstOrDefault();
        }
        public static IEnumerable<Int32> Positions<TSource>(this IEnumerable<TSource> source, 
                                                            Func<TSource, bool> predicate)
        {
            if (typeof(TSource) is IDictionary)
            {
                throw new Exception("Dictionaries aren't supported");
            }
            if (source == null)
            {
                throw new ArgumentOutOfRangeException("source is null");
            }
            if (predicate == null)
            {
                throw new ArgumentOutOfRangeException("predicate is null");
            }
            var found = source.Where(predicate).First();
            var query = source.Select((item, index) => new
                {
                    Found = ReferenceEquals(item, found),
                    Index = index
                }).Where( it => it.Found).Select( it => it.Index);
            return query;
        }
    }
