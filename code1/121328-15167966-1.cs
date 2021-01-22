    public static class GetValueOrDefaultExtension
    {
        public static TResult GetValueOrDefault<TSource, TResult>(this TSource source, Func<TSource, TResult> selector)
        {
            try { return selector(source); }
            catch { return default(TResult); }
        }
    }
