    public static Extensions
    {
        public static TColl ToTypedCollection<TColl, T>(this IEnumerable ien)
            where TColl : IList<T>, new()
        {
            TColl collection = new TColl();
            foreach (var item in ien)
            {
                collection.Add((T) item);
            }
            return collection;
        }
    }
