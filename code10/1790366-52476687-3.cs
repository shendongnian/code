    static class CountExtensions {
        public static int? TryCount<T>(this IEnumerable<T> items) {
            switch (items) {
                case ICollection<T> genCollection:
                    return genCollection.Count;
                case ICollection legacyCollection:
                    return legacyCollection.Count;
                case IReadOnlyCollection<T> roCollection:
                    return roCollection.Count;
                default:
                    return null;
            }
        }
    }
