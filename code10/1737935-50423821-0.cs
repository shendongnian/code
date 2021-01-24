    static class Maker<T>
    {
        public static Func<Interface2<T>> Func { get; private set; }
        public static Interface2<T> New()
        {
            if (Func == null)
            {
                Func = Expression.Lambda<Func<Interface2<T>>>(Expression.New(typeof(Class1<>).MakeGenericType(typeof(T)))).Compile();
            }
            return Func();
        }
    }
