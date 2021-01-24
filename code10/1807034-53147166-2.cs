    public static class EnumerableExtensions
    {
        public static IList<T> GetListOrNull<T>(this IEnumerable<T> items)
        {
            if (items == null)
            {
                return null;
            }
            // optimization to avoid creating a new list when the input already implements `IList`
            if (!(items is IList<T> tmp))
            {
                tmp = items.ToList();
            }
            return tmp.Any() ? tmp : null;
        }
        // or a list-specific version
        public static IList<T> GetListOrNull<T>(this IList<T> items)
        {
            if (items == null)
            {
                return null;
            }
            return items.Any() ? items : null;
        }
    }
