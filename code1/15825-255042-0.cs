    static class PropertyCache<T>
    {
        private static SomeCacheType cache;
        public static SomeCacheType Cache
        {
            get
            {
                if (cache == null) Build();
                return cache;
            }
        }
        static void Build()
        {
            /// populate "cache"
        }
    }
