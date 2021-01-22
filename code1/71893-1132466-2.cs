    public static IEnumerable<T> OrderedIntersect<T>(this IEnumerable<T> source, IEnumerable<T> other) where T : IComparable
    {
        using (var xe = source.GetEnumerator())
        using (var ye = other.GetEnumerator())
        {
            while (xe.MoveNext())
            {
               while (ye.MoveNext() && ye.Current.CompareTo(xe.Current) < 0 )
               {
                  // do nothing - all we care here is that we advanced the y enumerator
               }
               if (ye.Current.Equals(xe.Current))
                  yield return xe.Current;
               else
               {  // y is now > x, so get x caught up again
                  while (xe.MoveNext() && xe.Current.CompareTo(ye.Current) < 0 )
                  { } // again: just advance, do do anything
                  if (xe.Current.Equals(ye.Current)) yield return xe.Current;
               }
            }
        }
    }
