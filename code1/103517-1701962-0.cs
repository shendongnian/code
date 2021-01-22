    namespace System
    {
    #if CSHARP2
        public delegate void Action();
        public delegate void Action<T>(T t);
        public delegate void Action<T, U>(T t, U u);
        public delegate void Action<T, U, V>(T t, U u, V v);
        public delegate TResult Func<TResult>();
        public delegate TResult Func<T, TResult>(T t);
        public delegate TResult Func<T, U, TResult>(T t, U u);
        public delegate TResult Func<T, U, V, TResult>(T t, U u, V v);
    #endif
    }
