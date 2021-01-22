    public static IEnumerable<T> MergePreserveOrder3<T, TOrder>(
        this IEnumerable<IEnumerable<T>> aa,
        Func<T, TOrder> orderFunc)
    where TOrder : IComparable<TOrder>
    {
        var items = aa.Select(xx => xx.GetEnumerator()).Where(ee => ee.MoveNext())
            .OrderBy(ee => orderFunc(ee.Current)).ToList();
        while (items.Count > 0)
        {
            yield return items[0].Current;
            var next = items[0];
            items.RemoveAt(0);
            if (next.MoveNext())
            {
                // simple sorted linear insert
                var value = orderFunc(next.Current);
                var ii = 0;
                for ( ; ii < items.Count; ++ii)
                {
                    if (value.CompareTo(orderFunc(items[ii].Current)) <= 0)
                    {
                        items.Insert(ii, next);
                        break;
                    }
                }
                if (ii == items.Count) items.Add(next);
            }
            else next.Dispose(); // woops! can't forget IDisposable
        }
    }
