    public static TypeFactory<T>
    {
        // There is one slot per T.
        private static ReadOnlyDictionary<string, T> cache;
        public static CreateInstance(string name)
        {
            return cache[name];
        }
    }
    string a = TypeFactory<string>("foo");
    int b = TypeFactory<int>("foo");
