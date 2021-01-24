    public static class EnumerableExtensions
    {
        public static IList<T> GetListOrNull<T>(IEnumerable<T> items)
        {
            if (items == null)
            {
                return null;
            }
            var tmp = items.ToList();
            return tmp.Count > 0 ? tmp : null;
        }
    }
