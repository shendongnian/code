    static IEnumerable<IGrouping<TFirst, TSecond>> Chunk<TFirst, TSecond>(
        IEnumerable<TFirst> source, 
        IEnumerable<TSecond> toChunk, 
        Func<TFirst, int> chunkSizeSelector)
    {
        //error checking here
        using (var chunkItems = toChunk.GetEnumerator())
        {
            foreach (var key in source)
            {
                List<TSecond> items = new List<TSecond>();
                for (int itemsRemaining = chunkSizeSelector(key); itemsRemaining > 0; itemsRemaining--)
                {
                    if (!chunkItems.MoveNext())
                        throw new ArgumentException("There are not enough items in toChunk to satisfy source.");
                    items.Add(chunkItems.Current);
                }
                yield return new ChunkGrouping<TFirst, TSecond>(key, items);
            }
        }
    }
    internal class ChunkGrouping<TKey, TElement> : IGrouping<TKey, TElement>
    {
        public ChunkGrouping(TKey key, IEnumerable<TElement> elements)
        {
            if (elements == null) throw new ArgumentNullException("elements");
            _key = key;
            _elements = elements;
        }
        private readonly TKey _key;
        private readonly IEnumerable<TElement> _elements;
        public TKey Key { get { return _key; } }
        IEnumerator<TElement> IEnumerable<TElement>.GetEnumerator()
        {
            return _elements.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _elements.GetEnumerator();
        }
    }
