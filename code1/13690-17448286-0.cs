    static class CollectionExtensions
    {
        public static ICollection<T> Clone<T>(this ICollection<T> listToClone)
        {
            var array = new T[listToClone.Count];
            listToClone.CopyTo(array,0);
            return array.ToList();
        }
    }
