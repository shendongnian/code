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
                     // for the while loop, so we've got to yield that result first
                     yield return firstIterator.Current;
                     if (!firstIterator.MoveNext())
                     {
                         break;
                     }
                }
                for (int i = 0; i < secondGrouping; i++)
                {
                     // This is a bit ugly, but it works...
                     if (!secondGrouping.MoveNext())
                     {
                         break;
                     }
                     yield return secondIterator.Current;
                }
            }
            while (secondIterator.MoveNext())
            {
                yield return secondIterator.Current;
            }
        }
    }
