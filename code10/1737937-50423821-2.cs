    static class Maker2<T>
    {
        public static Func<Interface2<T>> Func { get; private set; }
        public static Interface2<T> New()
        {
            if (Func == null)
            {
                if (typeof(Interface1).IsAssignableFrom(typeof(T)))
                {
                    Func = Expression.Lambda<Func<Interface2<T>>>(Expression.New(typeof(Class1<>).MakeGenericType(typeof(T)))).Compile();
                }
                else
                {
                    Func = Expression.Lambda<Func<Interface2<T>>>(Expression.New(typeof(Class2<>).MakeGenericType(typeof(T)))).Compile();
                }
            }
            return Func();
        }
    }
