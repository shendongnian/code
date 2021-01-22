    public static IEnumerable<TResult> PairUp<TFirst,TSecond,TResult>
        (this IEnumerable<TFirst> source, IEnumerable<TSecond> secondSequence,
         Func<TFirst,TSecond,TResult> projection)
    {
        using (IEnumerator<TSecond> secondIter = secondSequence.GetEnumerator())
        {
            foreach (TFirst first in source)
            {
                if (!secondIter.MoveNext())
                {
                    throw new ArgumentException
                        ("First sequence longer than second");
                }
                yield return projection(first, secondIter.Current);
            }
            if (secondIter.MoveNext())
            {
                throw new ArgumentException
                    ("Second sequence longer than first");
            }
        }        
    }
