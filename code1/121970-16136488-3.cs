    static public IEnumerable<T> Swap4<T>(this IEnumerable<T> source, int index1, int index2)
    {
        // Parameter checking is skipped in this example.
        // It is assumed that index1 < index2. Otherwise a check should be build in and both indexes should be swapped.
        using(IEnumerator<T> e = source.GetEnumerator())
        {
            // Iterate to the first index.
            for(int i = 0; i < index1; i++) 
            {
                if (!e.MoveNext())
                    yield break;
                yield return e.Current;
            }
            if (index1 != index2)
            {
                // Remember the item at the first position.
                if (!e.MoveNext())
                    yield break;
                T rememberedItem = e.Current;
                // Store the items between the first and second index in a temporary list. 
                List<T> subset = new List<T>(index2 - index1 - 1);
                for (int i = index1 + 1; i < index2; i++)
                {
                    if (!e.MoveNext())
                        break;
                    subset.Add(e.Current);
                }
                // Return the item at the second index.
                if (e.MoveNext())
                    yield return e.Current;
                // Return the items in the subset.
                foreach (T item in subset)
                    yield return item;
                // Return the first (remembered) item.
                yield return rememberedItem;
            }
            // Return the remaining items in the list.
            while (e.MoveNext())
                yield return e.Current;
        }
    }
