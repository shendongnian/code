    /// <summary>
    /// <para>For two sorted IEnumerable&lt;T&gt; (superset and subset),</para>
    /// <para>returns the values in superset which are not in subset.</para>
    /// </summary>
    public static IEnumerable<T> CompareSortedEnumerables<T>(IEnumerable<T> superset, IEnumerable<T> subset)
        where T : IComparable
    {
        IEnumerator<T> supersetEnumerator = superset.GetEnumerator();
        IEnumerator<T> subsetEnumerator = subset.GetEnumerator();
        bool itemsRemainingInSubset = subsetEnumerator.MoveNext();
        // handle the case when the first item in subset is less than the first item in superset
        T firstInSuperset = superset.First();
        while ( itemsRemainingInSubset && supersetEnumerator.Current.CompareTo(subsetEnumerator.Current) >= 0 )
            itemsRemainingInSubset = subsetEnumerator.MoveNext();
        while ( supersetEnumerator.MoveNext() )
        {
            int comparison = supersetEnumerator.Current.CompareTo(subsetEnumerator.Current);
            if ( !itemsRemainingInSubset || comparison < 0 )
            {
                yield return supersetEnumerator.Current;
            }
            else if ( comparison >= 0 )
            {
                while ( itemsRemainingInSubset && supersetEnumerator.Current.CompareTo(subsetEnumerator.Current) >= 0 )
                    itemsRemainingInSubset = subsetEnumerator.MoveNext();
            }
        }
    }
