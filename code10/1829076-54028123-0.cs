    static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>
      (IEnumerable<TOuter> outer, 
      IEnumerable<TInner> inner, 
      Func<TOuter, TKey> outerKeySelector, 
      Func<TInner, TKey> innerKeySelector, 
      Func<TOuter, TInner, TResult> resultSelector, 
      IEqualityComparer<TKey> comparer) 
    {
      var lookup = new SomeMultiDictionary<TKey, TInner>(comparer);
      foreach(TInner innerItem in inner)
      {
        TKey innerKey = innerKeySelector(innerItem);
        lookup.Add(innerItem, innerKey);
      }
      foreach (TOuter outerItem in outer) 
      {
        TKey outerKey = outerKeySelector(outerItem);
        foreach(TInner innerItem in lookup[outerKey])
        {
          TResult result = resultSelector(outerItem, innerItem);
          yield return result;
        }
      }
    }
