    class Indexer
    {
        public int  Index;
        public bool Finished;
    }
    public static IEnumerable<IEnumerable<T>> PartitionBy<T>(this IEnumerable<T> sequence, Func<T, int, bool> predicate)
    {
        var iter = sequence.GetEnumerator();
        var indexer = new Indexer();
        while (!indexer.Finished)
        {
            yield return nextBlock(iter, predicate, indexer);
        }
    }
    static IEnumerable<T> nextBlock<T>(IEnumerator<T> iter, Func<T, int, bool> predicate, Indexer indexer)
    {
        int index = indexer.Index;
        bool any = false;
        while (true)
        {
            if (!iter.MoveNext())
            {
                indexer.Finished = true;
                yield break;
            }
            if (predicate(iter.Current, index++))
            {
                any = true;
                yield return iter.Current;
            }
            else
            {
                indexer.Index = index;
                if (any)
                    yield break;
            }
        }
    }
