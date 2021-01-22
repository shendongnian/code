    public static class BusinessUtil
    {
        public static T Load<T>(ServiceContext context)
        {
            if (typeof(T) == typeof(Object1))
                return (T) Object1.Load(context);
            if (typeof(T) == typeof(Object2))
                return (T) Object2.Load(context);
            // ... etc.
        }
    }
