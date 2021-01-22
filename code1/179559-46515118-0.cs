    public static class LinQExtensions
    {
        public static IEnumerable<TResult> LeftJoin<TOuter, TInner, TKey, TResult>(
            this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, 
            Func<TOuter, TKey> outerKeySelector, 
            Func<TInner, TKey> innerKeySelector, 
            Func<TOuter, TInner, TResult> resultSelector)
        {
            return outer.GroupJoin(
                inner, 
                outerKeySelector, 
                innerKeySelector,
                (outerElement, innerElements) => resultSelector(outerElement, innerElements.FirstOrDefault()));
        }
    }
