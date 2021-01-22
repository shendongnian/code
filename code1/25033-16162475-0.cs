    public static class New<T>
    {
        public static readonly Func<T> Instance;
        static New()
        {
            Type t = typeof(T);
            Instance = t.HasDefaultConstructor() 
                     ? Expression.Lambda<Func<T>>(Expression.New(t)).Compile()
                     : () => (T)FormatterServices.GetUninitializedObject(t);
        }
    }
    public static bool HasDefaultConstructor(this Type t)
    {
        return t.IsValueType || t.GetConstructor(Type.EmptyTypes) != null;
    }
