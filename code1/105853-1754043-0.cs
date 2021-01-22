        public static void AddRange<T, TK>(this ICollection<T> collection, IEnumerable<TK> list) where TK : T
        {
            foreach (var item in list)
            {
                collection.Add(item);
            }
        }
