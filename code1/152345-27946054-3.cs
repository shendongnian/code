    public static IEnumerable<T> Merge<T, TOrder>(this IEnumerable<IEnumerable<T>> TEnumerable_2, Func<T, TOrder> orderFunc, IComparer<TOrder> cmp=null)
    {
        if (cmp == null)
        {
            cmp = Comparer<TOrder>.Default;
        }
        List<IEnumerator<T>> TEnumeratorLt = TEnumerable_2
           .Select(l => l.GetEnumerator())
           .Where(e => e.MoveNext())
           .ToList();
        while (TEnumeratorLt.Count > 0)
        {
            int intMinIndex;
            IEnumerator<T> TSmallest = TEnumeratorLt.GetMin(TElement => orderFunc(TElement.Current), out intMinIndex, cmp);
            yield return TSmallest.Current;
            if (TSmallest.MoveNext() == false)
            {
                TEnumeratorLt.RemoveAt(intMinIndex);
            }
        }
    }
    /// <summary>
    /// Get the first min item in an IEnumerable, and return the index of it by minIndex
    /// </summary>
    public static T GetMin<T, TOrder>(this IEnumerable<T> self, Func<T, TOrder> orderFunc, out int minIndex, IComparer<TOrder> cmp = null)
    {
        if (self == null) throw new ArgumentNullException("self");            
        IEnumerator<T> selfEnumerator = self.GetEnumerator();
        if (!selfEnumerator.MoveNext()) throw new ArgumentException("List is empty.", "self");
        if (cmp == null) cmp = Comparer<TOrder>.Default;
        T min = selfEnumerator.Current;
        minIndex = 0;
        int intCount = 1;
        while (selfEnumerator.MoveNext ())
        {
            if (cmp.Compare(orderFunc(selfEnumerator.Current), orderFunc(min)) < 0)
            {
                min = selfEnumerator.Current;
                minIndex = intCount;
            }
            intCount++;
        }
        return min;
    }
