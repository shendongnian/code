    public static class Extensions
    {
        public static bool HasElements<T>(this IEnumerable<T> collection)
        {
            foreach (T t in collection)
                return true;
            return false;
        }
    }
