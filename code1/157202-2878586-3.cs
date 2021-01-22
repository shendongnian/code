    public static class CollectionExtensions
    {
        public static TCollection AsEmpty<TCollection>(this TCollection source)
            where TCollection : ICollection, new()
        {
            return new TCollection();
        }
    }
