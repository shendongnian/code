    public static IEnumerable<T> SafeCast<T>(IEnumerable source)
    {
        foreach (T item in source)
        {
            yield return item;
        }
    }
    return SafeCast<IMyInterface>(MyObjects);
