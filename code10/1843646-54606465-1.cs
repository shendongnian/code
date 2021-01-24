    private static IEnumerable<object> Merge(IEnumerable<float> sequence1, IEnumerable<int> sequence2)
    {
        // Get enumerators for iterating through the two sequences.
        using (var enumerator1 = sequence1.GetEnumerator())
        using (var enumerator2 = sequence2.GetEnumerator())
        {
            var remaining1 = enumerator1.MoveNext();
            var remaining2 = enumerator2.MoveNext();
            while (remaining1 && remaining2)
            {
                if (enumerator1.Current < enumerator2.Current)
                {
                    yield return enumerator1.Current;
                    remaining1 = enumerator1.MoveNext();
                }
                else
                {
                    yield return enumerator2.Current;
                    remaining2 = enumerator2.MoveNext();
                }
            }
            if (remaining1)
            {
                do { yield return enumerator1.Current; }
                while (enumerator1.MoveNext());
            }
            else if (remaining2)
            {
                do { yield return enumerator2.Current; }
                while (enumerator2.MoveNext());
            }
        }
    }
