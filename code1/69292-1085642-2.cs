    public T Max<T>(IEnumerable<T> items)
    {
        Comparer<T> comparer = Comparer<T>.Default;
        using (IEnumerator<T> iterator = items.GetEnumerator())
        {
            if (!iterator.MoveNext())
            {
                throw new InvalidOperationException("No elements");
            }
            T currentMax = iterator.Current;
            // Now we've got an initial value, loop over the rest
            while (iterator.MoveNext())
            {
                T candidate = iterator.Current;
                if (comparer.Compare(candidate, currentMax) > 0)
                {
                    currentMax = candidate;
                }
            }
            return currentMax;
        }
    }
