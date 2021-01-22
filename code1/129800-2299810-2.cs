    using System;
    using System.Collections.Generic;
    public static class Splitter
    {
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> source, Predicate<T> match)
        {
            using (IEnumerator<T> enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    yield return Split(enumerator, match);
                }
            }
        }
        static IEnumerable<T> Split<T>(IEnumerator<T> enumerator, Predicate<T> match)
        {
            do
            {
                if (match(enumerator.Current))
                {
                    yield break;
                }
                else
                {
                    yield return enumerator.Current;
                }
            } while (enumerator.MoveNext());
        }
    }
