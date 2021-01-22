    public static class HashSetExtensions
    {
        public static bool AddNonNull<T>(this HashSet<T> set, T item)
            where T : class
        {
            if (item == null)
                return false;
            return set.Add(item);
        }
    }
