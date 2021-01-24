    public static class LinqExtentions
    {
        public static void Project<T>(this IEnumerable<T> lst1, IEnumerable<T> lst2,
            Func<T, object> key, Action<T, T> action)
        {
            foreach (var item1 in lst1)
            {
                var item2 = lst2.FirstOrDefault(x => key(x).Equals(key(item1)));
                if (item2 != null)
                {
                    action(item1, item2);
                }
            }
        }
    }
