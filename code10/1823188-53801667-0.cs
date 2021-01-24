    public static class WithExtension
    {
        public static void With<T>(this T o, Action<T> values)
        {
            values?.Invoke(o);
        }
    }
