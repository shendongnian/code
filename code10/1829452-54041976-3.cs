    [IteratorStateMachine(typeof(<Silly>d__1)), Extension]
    private static IEnumerable<T> Silly<T>(this IEnumerable<T> source)
    {
        IEnumerator<T> <sillier>5__1;
        using (<sillier>5__1 = source.GetEnumerator())
        {
            while (<sillier>5__1.MoveNext())
            {
                yield return <sillier>5__1.Current;
            }
        }
        <sillier>5__1 = null;
    }
