    public static IEnumerable<T> InterleaveWith<T>
       (this IEnumerable<T> first, IEnumerable<T> second,
        int firstGrouping, int secondGrouping)
    {
        using (IEnumerator<T> firstIterator = first.GetEnumerator())
        using (IEnumerator<T> secondIterator = second.GetEnumerator())
        {
            bool exhaustedFirst = false;
            // Keep going while we've got elements in the first sequence.
            while (!exhaustedFirst)
            {                
                for (int i = 0; i < firstGrouping; i++)
                {
                     if (!firstIterator.MoveNext())
                     {
                         exhaustedFirst = true;
                         break;
                     }
                     yield return firstIterator.Current;
                }
                // This may not yield any results - the first sequence
                // could go on for much longer than the second. It does no
                // harm though; we can keep calling MoveNext() as often
                // as we want.
                for (int i = 0; i < secondGrouping; i++)
                {
                     // This is a bit ugly, but it works...
                     if (!secondIterator.MoveNext())
                     {
                         break;
                     }
                     yield return secondIterator.Current;
                }
            }
            // We may have elements in the second sequence left over.
            // Yield them all now.
            while (secondIterator.MoveNext())
            {
                yield return secondIterator.Current;
            }
        }
    }
