    public static System.ComponentModel.ListSortDirection? SortDirection<T>(this IEnumerable<T> items, Comparer<T> comparer = null)
    {
        if (items == null) throw new ArgumentNullException("items");
        if (comparer == null) comparer = Comparer<T>.Default;
        bool ascendingOrder = true; bool descendingOrder = true;
        using (var e = items.GetEnumerator())
        {
            e.MoveNext();
            T last = e.Current;
            while (e.MoveNext())
            {
                int diff = comparer.Compare(last, e.Current);
                if (diff > 0)
                    ascendingOrder = false;
                else if(diff < 0)
                    descendingOrder = false;
                if (!ascendingOrder && !descendingOrder) 
                    return null;
                last = e.Current;
            }
        }
        if (ascendingOrder)
            return System.ComponentModel.ListSortDirection.Ascending;
        else if (descendingOrder)
            return System.ComponentModel.ListSortDirection.Descending;
        else
            return null;
    }
