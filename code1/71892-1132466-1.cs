    public static IEnumerable<T> OrderedIntersect<T>(this IEnumerable<T> source, IEnumerable<T> other)
    {
        using (var xe = source.GetEnumerator())
        using (var ye = other.GetEnumerator())
        {
            while (xe.MoveNext())
            {
               while (ye.MoveNext() && ye.Current < xe.Current)
               {
                  // do nothing - all we care here is that we advanced the y enumerator
               }
               if (ye.Current.Equals(xe.Current))
                  yield return xe.Current;
               else
               {  // y is now > x, so get x caught up again
                  while (xe.MoveNext() && xe.Current < ye.Current) 
                  { } // again: just advance, do do anything
                  if (xe.Current.Equals(ye.Current)) yield return xe.Current;
               }
            }
        }
    }
