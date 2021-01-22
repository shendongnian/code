    public static class MyExtensionMethods
    {
        public static Type GetRealType<T>(this T source)
        {
            Type t = typeof(T);
            if ((source == null) || (Nullable.GetUnderlyingType(t) != null))
                return t;
            return source.GetType();
        }
    }
