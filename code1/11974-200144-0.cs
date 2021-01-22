    public static IEnumerable Flatten<T>(IEnumerable e)
    {
        if (e == null) yield break;
        foreach (var item in e)
        {
            if (item is T)
               yield return (T)item;
            else if (item is IEnumerable)
            {
                foreach (var subitem in Flatten<T>((IEnumerable)item))
                    yield return subitem;
            }
            else
               yield return item;
        }
    }
