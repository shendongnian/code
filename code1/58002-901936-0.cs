    public static class Extensions{
        public static IEnumerable<T> CastByExample<T>(
                this IEnumerable sequence, 
                T example) where T: class
        {
            foreach (Object o in sequence)
                yield return o as T;
        }
    }
