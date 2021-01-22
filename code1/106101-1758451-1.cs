    public static IEnumerable<T> InterleaveWith<T>
       (this IEnumerable<T> first, IEnumerable<T> second,
        int firstGrouping, int secondGrouping)
    {
        using (IEnumerator<T> firstIterator = first.GetEnumerator())
        using (IEnumerator<T> secondIterator = second.GetEnumerator())
        {
            // Keep going while we've got elements in the first sequence.
            while (firstIterator.MoveNext())
            {                
                for (int i = 0; i < firstGrouping; i++)
                {
                     // On the first iteration, we've already called MoveNext()
                     // for the while loop, so we've got to yield that result
                     // before we call MoveNext again.
                     yield return firstIterator.Current;
                     if (!firstIterator.MoveNext())
                     {
                         break;
                     }
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
