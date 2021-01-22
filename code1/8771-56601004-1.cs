        public static void ForEach<T, U>(this Dictionary<T, U> d, Action<KeyValuePair<T, U>> a)
        {
            foreach (KeyValuePair<T, U> p in d) { a(p); }
        }
        public static void ForEach<T, U>(this Dictionary<T, U>.KeyCollection k, Action<T> a)
        {
            foreach (T t in k) { a(t); }
        }
        public static void ForEach<T, U>(this Dictionary<T, U>.ValueCollection v, Action<U> a)
        {
            foreach (U u in v) { a(u); }
        }
