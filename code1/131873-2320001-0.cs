    public static Tuple<IEnumerable<T>, IEnumerable<T>, IEnumerable<T>> ComparativeWhere<T>(this IEnumerable<T> source, T t)
    where T : IComparable<T>
    {
        var list1 = new List<T>();
        var list2 = new List<T>();
        var list3 = new List<T>();
        foreach (var item in source)
        {
            if (item.CompareTo(t) < 0)
            {
                list1.Add(item);
            }
            if (item.CompareTo(t) == 0)
            {
                list2.Add(item);
            }
            if (item.CompareTo(t) > 0)
            {
                list3.Add(item);
            }
        }
        return new Tuple<IEnumerable<T>, IEnumerable<T>, IEnumerable<T>>(list1, list2, list3);
    }
