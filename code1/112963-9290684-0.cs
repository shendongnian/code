    public static TResult DuplicateDelegateAs<TResult>(MulticastDelegate source)
    {
        Delegate result = null;
        foreach (Delegate sourceItem in source.GetInvocationList())
        {
            var copy = Delegate.CreateDelegate(
                typeof(TResult), sourceItem.Target, sourceItem.Method);
            result = Delegate.Combine(result, copy);
        }
        return (TResult) (object) result;
    }
