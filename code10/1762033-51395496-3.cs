    public static IEnumerable<TSource> TakeFirstOne<TSource>(this IEnumerable<TSource> source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        using (IEnumerator<TSource> enumerator = source.GetEnumerator())
        {
            if (enumerator.MoveNext())
            {   // there is at least one element in the section.
                TSource firstDifferentItem = enumerator.Current;
                yield return firstDifferentItem;
                
                // continue enumerating:
                while(enumerator.MoveNext())
                {
                    // if Current not equal: yield return
                    if (!firstDifferentItem.Equals(enumerator.Current))
                    {
                         firstDifferentItem = enumerator.Current;
                         yield return firstDifferentItem;
                    }
                }
            }
        }
    }
