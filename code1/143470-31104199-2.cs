       using System;
       using System.Collections.Generic;
       using System.Linq;
       namespace fNns
       {
           public class indexer<T> where T : IEquatable<T>
           {
               public T t { get; set; }
               public int index { get; set; }
           }
           public static class fN
           {
               public static indexer<T> findNth<T>(IEnumerable<T> tc, T t,
                   int occurrencePosition) where T : IEquatable<T>
               {
                   var result = tc.Select((ti, i) => new indexer<T> { t = ti, index = i })
                          .Where(item => item.t.Equals(t))
                          .Skip(occurrencePosition - 1)
                          .FirstOrDefault();
                   return result;
               }
               public static indexer<T> findNthReverse<T>(IEnumerable<T> tc, T t,
           int occurrencePosition) where T : IEquatable<T>
               {
                   var result = tc.Reverse<T>().Select((ti, i) => new indexer<T> {t = ti, index = i })
                          .Where(item => item.t.Equals(t))
                          .Skip(occurrencePosition - 1)
                          .FirstOrDefault();
                   return result;
               }
           }
       }
