    public static class IEnumerableExtenions
    {
        public static IEnumerable<T> UnionIfNotNull<T>(this IEnumerable<T> list1, IEnumerable<T> list2)
        {
            if (list1 != null && list2 != null)
                return list1.Union(list2);
            else if (list1 != null)
                return list1;
            else if (list2 != null)
                return list2;
            else return null;
        }
    }
