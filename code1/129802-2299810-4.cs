    using System;
    using System.Collections.Generic;
    using System.Linq;
    public static class Splitter2
    {
        public static IEnumerable<IEnumerable<T>> SplitToSegments<T>(this IEnumerable<T> source, Predicate<T> match)
        {
            T[] items = source.ToArray();
            for (int startIndex = 0; startIndex < items.Length; startIndex++)
            {
                int endIndex = startIndex;
                for (; endIndex < items.Length; endIndex++)
                {
                    if (match(items[endIndex])) break;
                }
                yield return EnumerateArraySegment(items, startIndex, endIndex - 1);
                startIndex = endIndex;
            }
        }
        static IEnumerable<T> EnumerateArraySegment<T>(T[] array, int startIndex, int endIndex)
        {
            for (; startIndex <= endIndex; startIndex++)
            {
                yield return array[startIndex];
            }
        }
    }
