    namespace System.Collections.Generic
    {
        using Linq;
    
        public static class EnumerableExtender
        {
            public static bool IsEmpty<T>(this IEnumerable<T> enumerable)
            {
                if (enumerable == null)
                    throw new ArgumentNullException(nameof(enumerable));
                var enumerator = enumerable.GetEnumerator();
                var moved = enumerator.MoveNext();
                return !moved;
            }
    
            public static IEnumerable<IEnumerable<T>> Partition<T>(this IEnumerable<T> source, int size)
                where T : struct
            {
                if (source == null)
                    throw new ArgumentNullException(nameof(source));
                if (size < 2)
                    throw new ArgumentOutOfRangeException(nameof(size));
                IEnumerable<T> items = source;
                IEnumerable<T> partition;
                while(true)
                {
                    items = items.Skip(size);
                    partition = items.Take(size);
                    if (partition.IsEmpty())
                        yield break;
                    else
                        yield return partition;
                }
            }
        }
    }
