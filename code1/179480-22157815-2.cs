    public static IEnumerable<Result> LeftJoin<TOuter, TInner, TKey, Result>(
      this IEnumerable<TOuter> outer, IEnumerable<TInner> inner
      , Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector
      , Func<TOuter, TInner, Result> resultSelector, IEqualityComparer<TKey> comparer)
      {
        if (outer == null)
          throw new ArgumentException("outer");
        if (inner == null)
          throw new ArgumentException("inner");
        if (outerKeySelector == null)
          throw new ArgumentException("outerKeySelector");
        if (innerKeySelector == null)
          throw new ArgumentException("innerKeySelector");
        if (resultSelector == null)
          throw new ArgumentException("resultSelector");
        return LeftJoinImpl(outer, inner, outerKeySelector, innerKeySelector, resultSelector, comparer ?? EqualityComparer<TKey>.Default);
      }
      static IEnumerable<Result> LeftJoinImpl<TOuter, TInner, TKey, Result>(
          IEnumerable<TOuter> outer, IEnumerable<TInner> inner
          , Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector
          , Func<TOuter, TInner, Result> resultSelector, IEqualityComparer<TKey> comparer)
      {
        var innerLookup = inner.ToLookup(innerKeySelector, comparer);
        foreach (var outerElment in outer)
        {
          var outerKey = outerKeySelector(outerElment);
          var innerElements = innerLookup[outerKey];
          if (innerElements.Any())
            foreach (var innerElement in innerElements)
              yield return resultSelector(outerElment, innerElement);
          else
            yield return resultSelector(outerElment, default(TInner));
         }
       }
