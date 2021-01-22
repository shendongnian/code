    public static IEnumerable<TResult> Cast<TSource, TResult>
        (IEnumerable<TSource> source)
    {
        foreach(TSource item in source)
        {
            yield return (TResult) (object) item;
        }
    }
