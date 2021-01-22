    // static class with generics
    public static class ListOps<T>
    {
        public static List<T> Filter(List<T> list, Func<T, bool> predicate) { ... }
        public static List<U> Map<U>(List<T> list, Func<T, U> convertor) { ... }
        public static U Fold<U>(List<T> list, U seed, Func<T, U> aggregator) { ... }
    }
    // vanilla static class
    public static class ListOps
    {
        public static List<T> Filter<T>(List<T> list, Func<T, bool> predicate) { ... }
        public static List<U> Map<T, U>(List<T> list, Func<T, U> convertor) { ... }
        public static U Fold<T, U>(List<T> list, U seed, Func<T, U> aggregator) { ... }
    }
