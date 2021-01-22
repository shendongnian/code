    public static IList<TResult>[] Split<TSource, TResult>(
        this IList<TSource> source,      // input IList to split
        Func<TSource, TResult> selector, // projection to apply to each item
        int elementCount                 // number of items per IList
    ) {
        // do something        
    }
