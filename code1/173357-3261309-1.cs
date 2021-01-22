    public static class TwoWayEnumeratorHelper
    {
        public static ITwoWayEnumerator<T> GetTwoWayEnumerator<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullExceptions("source");
    
            return new TwoWayEnumerator<T>(source.GetEnumerator());
        }
    }
