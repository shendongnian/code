    public static class UpTo<T>
    {
        public static IEnumerable<T> From<F>(IEnumerable<F> source) where F:T
        {
            // this cast is guaranteed to work
            return source.Select(f => (T) f);
        }
    }
