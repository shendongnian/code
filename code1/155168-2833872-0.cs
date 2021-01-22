    public IEnumerable<TResult> OfType<TResult>(IEnumerable source)
    {
        foreach (object item in source)
        {
            if (item is TResult)
                yield return (TResult)item;
        }
    }
