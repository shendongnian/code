    public static IEnumerable<TItem> Get<TItem>(IList<TItem> list)
    {
        if (list == null)
            yield break;
    
        for (int i = list.Count - 1; i > -1; i--)
            yield return list[i];
    }
