    public static class New<T>
    {
        public static readonly Func<T> Instance = Creator();
        
        static Func<T> Creator()
        {
            Type t = typeof(T);
            if (t == typeof(string))
                return Expression.Lambda<Func<T>>(Expression.Constant(string.Empty)).Compile();
            if (t.HasDefaultConstructor())
                return Expression.Lambda<Func<T>>(Expression.New(t)).Compile();
            return () => (T)FormatterServices.GetUninitializedObject(t);
        }
    }
    public static bool HasDefaultConstructor(this Type t)
    {
        return t.IsValueType || t.GetConstructor(Type.EmptyTypes) != null;
    }
