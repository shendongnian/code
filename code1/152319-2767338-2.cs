    public static IEnumerable<T> MergePreserveOrder<T, TOrder>(
                        this IEnumerable<IEnumerable<T>> aa,
                        Func<T, TOrder> orderFunc) 
    where TOrder : IComparable<TOrder>
    {
        var items = aa.Select(xx => xx.GetEnumerator())
                      .Where(ee => ee.MoveNext())
                      .ToList();
        while (items.Count > 0)
        {
            items.Sort(
                 (xx, yy) => orderFunc(xx.Current).CompareTo(orderFunc(yy.Current)));
            yield return items[0].Current;
            if (!items[0].MoveNext())
            {
                items.RemoveAt(0);
            }
        }
    }
