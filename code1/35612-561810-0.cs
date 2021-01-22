    public static class IEnumerableExtensions
    {
        public static T SingleOrNew<T>( this IEnumerable<T> query ) where T : new()
        {
            var value = query.SingleOrDefault();
            if (value == null)
            {
                value = new T();
            }
            return value;
        }
    }
