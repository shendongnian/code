    IEnumerable<T> Merge<T>(this IEnumerable<T> coll, 
                          Func<T,T,bool> canBeMerged, Func<T,T,T>mergeItems)
    {
        using(IEnumerator<T> iter = col.GetEnumerator())
        {
          if (iter.MoveNext())
          {
              T lhs = iter.Current;
              while(iter.MoveNext())
              {
                  T rhs = iter.Current;
                  if (canBeMerged(lhs, rhs)
                     lhs=mergeItems(lhs, rhs);
                  else
                  {
                     yield return lhs;
                     lhs= rhs;
                  }
              }
              yield return lhs;
          }
        }
    }
