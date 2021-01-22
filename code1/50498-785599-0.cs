    public static class MyExtensionMethods
    {
        public static Type GetRealType<T>(this T source)
        {
            return typeof(T);
        }
    }
