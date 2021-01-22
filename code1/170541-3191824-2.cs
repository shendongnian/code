    static class MyExtensions
    {
        static IEnumerable<T> IntersectAllIfEmpty<T>(this IEnumerable<T> list, IEnumerable<T> other)
        {
            if (list.Any())
            {
                if (other.Any())
                    return list.Intersect(other);
                else
                    return list;
            }
            else
            {
                return other;
            }
        }
    }
