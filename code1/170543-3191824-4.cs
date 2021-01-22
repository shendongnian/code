    static class MyExtensions
    {
        public static IEnumerable<T> IntersectAllIfEmpty<T>(this IEnumerable<T> list, IEnumerable<T> other)
        {
            if (other.Any())
                return list.Intersect(other);
            else
                return list;
        }
    }
