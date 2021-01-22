    public static bool IsSorted<T>(this IEnumerable<T> items, Comparer<T> comparer = null)
    {
        if (items == null) throw new ArgumentNullException("items");
        var rest = items.Skip(1);
        if (!rest.Any()) return true;  // 0 or 1 items
        if (comparer == null) comparer = Comparer<T>.Default;
        bool ascendingOrder = true; bool descendingOrder = true;
        T last = items.First();
        foreach (T current in rest)
        {
            int diff = comparer.Compare(last, current);
            if (diff > 0)
            {
                ascendingOrder = false;
            }
            if (diff < 0)
            {
                descendingOrder = false;
            }
            last = current;
            if (!ascendingOrder && !descendingOrder) return false;
        }
        return (ascendingOrder || descendingOrder);
    }
