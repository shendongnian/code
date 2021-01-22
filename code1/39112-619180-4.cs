    using System.Collections.Generic;
    // This must be a non-nested type, and must be static to allow the extension
    // method.
    public static class Extensions
    {
        public static IEnumerable<TResult> SelectPairs<TSource, TResult>
            (this IEnumerable<TSource> source,
             Func<TSource, TSource, TResult> selector)
        {
            using (IEnumerator<TSource> iterator = source.GetEnumerator())
            {
               if (!iterator.MoveNext())
               {
                   yield break;
               }
               TSource prev = iterator.Current;
               while (iterator.MoveNext())
               {
                   TSource current = iterator.Current;
                   yield return selector(prev, current);
                   prev = current;
               }
            }
        }
    }
