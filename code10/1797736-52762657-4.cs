    public static class CacheKeys
    {
        public static string GetIdKey<TEntity>() => $"_Id{typeof(TEntity).Name}";
        public static string GetNameKey<TEntity>() => $"_{typeof(TEntity).Name}Name";
    }
