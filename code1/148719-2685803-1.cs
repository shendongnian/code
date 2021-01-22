    public static TypeFactory<T> where T : new()
    {
        // There is one slot per T.
        private static readonly object instance = new T();
        public static object GetInstance() {
            return instance;
        }
    }
    string a = (string)TypeFactory<string>.GetInstance();
    int b = (int)TypeFactory<int>.GetInstance();
