<!-- -->
    public static class ChainAdd
    {
        public static ICollection&lt;T&gt; AddItem&lt;T&gt;(this ICollection&lt;T&gt; collection, T item)
        {
            collection.Add(item);
            return collection;
        }
    }
