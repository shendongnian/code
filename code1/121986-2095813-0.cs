    public static bool IsEmpty<T>(this IEnumerable<T> items) {
            using (var enumerator = items.GetEnumerator())
            {
                return !enumerator.MoveNext();
            }
     }
