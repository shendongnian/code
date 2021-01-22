    class C<T>
    {
        public static Type CT() { return typeof(C<T>); }
        public static Type JustC() { return typeof(C<>); }
    }
