    static public IEnumerable<T> Swap3<T>(this IList<T> source, int index1, int index2)
    {
        // Parameter checking is skipped in this example.
        // It is assumed that index1 < index2. Otherwise a check should be build in and both indexes should be swapped.
        using (IEnumerator<T> e = source.GetEnumerator())
        {
            // Iterate to the first index.
            for (int i = 0; i < index1; i++)
                yield return source[i];
            // Return the item at the second index.
            yield return source[index2];
            if (index1 != index2)
            {
                // Return the items between the first and second index.
                for (int i = index1 + 1; i < index2; i++)
                    yield return source[i];
                // Return the item at the first index.
                yield return source[index1];
            }
            // Return the remaining items.
            for (int i = index2 + 1; i < source.Count; i++)
                yield return source[i];
        }
    }
