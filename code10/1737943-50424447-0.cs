    static void InsertSorted<T>(IList<T> list, T item) where T : IComparable<T> {
        list.Add(item);
        var i = list.Count-1;
        for ( ; i > 0 && list[i-1].CompareTo(item) < 0 ; i--) {
            list[i] = list[i-1];
        }
        list[i] = item;
    }
