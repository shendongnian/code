    public static class EntityCollectionHelper
    {
        public static EntitySet<T> ToEntitySet<T>(this IEnumerable<T> source) where T:class
        {
            EntitySet<T> set = new EntitySet<T>();
            set.AddRange(source);
            return set;
        }
    }
