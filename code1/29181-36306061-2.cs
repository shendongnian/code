    namespace System
    {
        public static class Lazy
        {
            public static Lazy<T> Create<T>(Func<T> factory) => new Lazy<T>(factory);
        }
    }
