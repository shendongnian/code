    namespace System.Collections.Generic
    {
        using Linq;
        using Runtime.CompilerServices;
    
        public static class EnumerableExtender
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool IsEmpty<T>(this IEnumerable<T> enumerable) => !enumerable?.GetEnumerator()?.MoveNext() ?? true;
    
            public static IEnumerable<IEnumerable<T>> Partition<T>(this IEnumerable<T> source, int size)
            {
                if (source == null)
                    throw new ArgumentNullException(nameof(source));
                if (size < 2)
                    throw new ArgumentOutOfRangeException(nameof(size));
                IEnumerable<T> items = source;
                IEnumerable<T> partition;
                while (true)
                {
                    partition = items.Take(size);
                    if (partition.IsEmpty())
                        yield break;
                    else
                        yield return partition;
                    items = items.Skip(size);
                }
            }
        }
    }
