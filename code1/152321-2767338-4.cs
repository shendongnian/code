    public static IEnumerable<T> MergePreserveOrder2<T, TOrder>(
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
                // binary insert (adapted from Wikipedia)
                var value = orderFunc(next.Current);
                int min = 0, max = items.Count;
                while (min < max)
                {
                    var mid = min + (max - min) / 2;
                    if (orderFunc(items[mid].Current).CompareTo(value) < 0)
                        min = mid + 1;
                    else
                        max = mid;
                }
                if (min < items.Count) items.Insert(min, next);
                else                   items.Add(next);
            }
        }
    }
