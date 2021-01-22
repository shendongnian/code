    public static TResult SafeGet<TSource, TResult>(this TSource source, Func<TSource, TResult> getResult) {
        if (source == null)
            return default(TResult);
        try {
            return getResult(source);
        }
        catch {
            return default(TResult);
        }
    }
