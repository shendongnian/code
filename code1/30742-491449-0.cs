     public static class extIList {
        public static IList<T> Sort<T, TKey>(this IList<T> list, SortOrder sortOrder, Func<T, TKey> keySelector) {
                if (sortOrder == SortOrder.Descending) {
                    return list.OrderByDescending(keySelector).ToList();
                } else {
                    return list.OrderBy(keySelector).ToList();
                }
        }
    }
