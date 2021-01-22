    public static class OutHelper<T>
    {
        [ThreadStatic]
        public static T Ignored;
    }
