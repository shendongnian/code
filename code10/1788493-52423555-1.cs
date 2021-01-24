    public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> enumerable, int[] indexes)
        {
            // Sort array.
            indexes = indexes.OrderBy(x => x).ToArray();
            var itemsReturned = 0;
            var list = enumerable.ToList();
            var count = list.Count;
            short i = 0;
            while (itemsReturned < count)
            {
                int currentChunkSize = i < indexes.Length
                                           ? Math.Min(indexes[i], count - itemsReturned)
                                           : count - itemsReturned;
                yield return list.GetRange(itemsReturned, currentChunkSize);
                itemsReturned += currentChunkSize;
                i++;
            }
        }
