    List<string> list = new List<string>();
    if (CS$<>9__CachedAnonymousMethodDelegate1 == null)
    {
        CS$<>9__CachedAnonymousMethodDelegate1 = new Predicate<string>(MyClass.<RunSnippet>b__0);
    }
    using (List<string>.Enumerator enumerator = list.FindAll(CS$<>9__CachedAnonymousMethodDelegate1).GetEnumerator())
    {
        while (enumerator.MoveNext())
        {
            string current = enumerator.Current;
        }
    }
    public List<T> FindAll(Predicate<T> match)
    {
        if (match == null)
        {
            ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
        }
        List<T> list = new List<T>();
        for (int i = 0; i < this._size; i++)
        {
            if (match(this._items[i]))
            {
                list.Add(this._items[i]);
            }
        }
        return list;
    }
    private static bool <RunSnippet>b__0(string o)
    {
        return (o.Length > 0);
    }
 
