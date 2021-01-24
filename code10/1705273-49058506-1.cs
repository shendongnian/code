    public static IEnumerable<(T PrevItem, T CurrentItem, T NextItem)>
            SlidingWindow<T>(this IEnumerable<T> source, T emptyValue = default)
    {
        using (var iter = source.GetEnumerator())
        {
            if (!iter.MoveNext())
                yield break;
            var prevItem = emptyValue;
            var currentItem = iter.Current;
            while (iter.MoveNext())
            {
                var nextItem = iter.Current;
                yield return (prevItem, currentItem, nextItem);
                prevItem = currentItem;
                currentItem = nextItem;
            }
            yield return (prevItem, currentItem, emptyValue);
        }
    }
