    public static class FactoryContructor<T>
    {
        private static readonly Func<T> New =
            Expression.Lambda<Func<T>>(Expression.New(typeof (T))).Compile();
        public static T Create()
        {
            return New();
        }
    }
