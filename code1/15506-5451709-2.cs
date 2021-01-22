    public static class Extensions
    {
        public static T Create<T>(this T @this)
            where T : class, new()
        {
            return Utility<T>.Create();
        }
    }
    public static class Utility<T>
        where T : class, new()
    {
        static Utility()
        {
            Create = Expression.Lambda<Func<T>>(Expression.New(typeof(T).GetConstructor(Type.EmptyTypes))).Compile();
        }
        public static Func<T> Create { get; private set; }
    }
