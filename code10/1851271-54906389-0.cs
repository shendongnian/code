    public static IEnumerable<IList<TSource>> Split<TSource>(this IEnumerable<TSource> source,
        int splitSize)
    {
        // todo: check for non-null source and positive splitSize
        var enumerator = source.GetEnumerator();
        while (enumerator.MoveNext())
        {
           // still elements to process. Create and fill the next splitList
           List<TSource> splitList = new List<TSource>(splitSize);
           splitList.Add(enumerator.Current()
           while (splitList.Count < splitSize && enumerator.MoveNext())
           {
               // still elements to add:
               splitList.Add(enumerator.Current);
           }
           // if here: either no more elements, or splitList full.
           yield return splitList;
        }
    }
