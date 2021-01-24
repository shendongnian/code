    static class QueryableExtensions
    {
        public static IQueryable<TResult> ToDeductibles<TSource, TResult, ...>(
           this IQueryable<TSource> source,
           ... other input parameters, keySelectors, resultSelectors, etc)
        {
             IQueryable<TResult> result = source... // use only supported LINQ methods
             return result;
        } 
    }
