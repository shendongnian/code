    public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<IEnumerable<T>> lists)
    {
        // Check against an empty list.
        if (!lists.Any())
        {
            yield break;
        }
        // Create a list of iterators into each of the sub-lists.
        List<IEnumerator<T>> iterators = new List<IEnumerator<T>>();
        foreach (var list in lists)
        {
            var it = list.GetEnumerator();
            // Ensure empty sub-lists are excluded.
            if (!it.MoveNext())
            {
                continue;
            }
            iterators.Add(it);
        }
        bool done = false;
        while (!done)
        {
            // Return the current state of all the iterator, this permutation.
            yield return from it in iterators select it.Current;
            // Move to the next permutation.
            bool recurse = false;
            var mainIt = iterators.GetEnumerator();
            mainIt.MoveNext(); // Move to the first, succeeds; the main list is not empty.
            do
            {
                recurse = false;
                var subIt = mainIt.Current;
                if (!subIt.MoveNext())
                {
                    subIt.Reset(); // Note the sub-list must be a reset-able IEnumerable!
                    subIt.MoveNext(); // Move to the first, succeeds; each sub-list is not empty.
                    if (!mainIt.MoveNext())
                    {
                        done = true;
                    }
                    else
                    {
                        recurse = true;
                    }
                }
            }
            while (recurse);
        }
    }
