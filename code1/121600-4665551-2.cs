    public static IEnumerable<TResult> FullOuterJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter,TKey> outerKeySelector, Func<TInner,TKey> innerKeySelector, Func<TOuter,TInner,TResult> resultSelector)
                    where TInner : class
                    where TOuter : class
                {
                    var innerLookup = inner.ToLookup(innerKeySelector);
                    var outerLookup = outer.ToLookup(outerKeySelector);
        
                    var innerJoinItems = inner
                        .Where(innerItem => !outerLookup.Contains(innerKeySelector(innerItem)))
                        .Select(innerItem => resultSelector(null, innerItem));
        
                    return outer
                        .SelectMany(outerItem =>
                            {
                                var innerItems = innerLookup[outerKeySelector(outerItem)];
        
                                return innerItems.Any() ? innerItems : EnumerableEx.Return<TInner>(null);
                            }, resultSelector)
                        .Concat(innerJoinItems);
                }
