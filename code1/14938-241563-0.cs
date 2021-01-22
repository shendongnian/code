    public static IEnumerable<TResult> PositionalJoin<T1, T2, TResult>(
        this IEnumerable<T1> source1, 
        IEnumerable<T2> source2, 
        Func<T1, T2, int, TResult> selector)
    {
        // argument checking here
        return PositionalJoinIterator(source1, source2, selector);
    }
    private static IEnumerable<TResult> PositionalJoinIterator<T1, T2, TResult>(
        IEnumerable<T1> source1, 
        IEnumerable<T2> source2, 
        Func<T1, T2, TResult> selector)
    {
        using (var enumerator1 = source1.GetEnumerator())
        using (var enumerator2 = source2.GetEnumerator())
        {
            bool gotItem;
            do
            {
                gotItem = false;
                T1 item1;
                if (enumerator1.MoveNext())
                {
                    item1 = enumerator1.Current;
                    gotItem = true;
                }
                else
                {
                    item1 = default(T1);
                }
                T2 item2;
                if (enumerator2.MoveNext())
                {
                    item2 = enumerator2.Current;
                    gotItem = true;
                }
                else
                {
                    item2 = default(T2);
                }
                if (gotItem)
                {
                    yield return selector(item1, item2);
                }
            }
            while (gotItem);
        }
    }
