    public static class EnumerableExtensions {
        public static T First<T>(this IEnumerable<T> source) {
            using (var e = source.GetEnumerator()) {
                if (!e.MoveNext())
                    throw new InvalidOperationException("The collection is empty.");
                return e.Current;
            }
        }
    }
