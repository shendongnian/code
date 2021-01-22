    public static class SortedListExtension
    {
        public static IEnumerable<KeyValuePair<TKey, TValue>> GetElementsGreaterThanOrEqual<TKey, TValue>(this SortedList<TKey, TValue> instance, TKey target) where TKey : IComparable<TKey>
        {
            int index = instance.BinarySearch(target);
            if (index < 0)
            {
                index = ~index;
            }
            for (int i = index; i < instance.Count; i++)
            {
                yield return new KeyValuePair<TKey, TValue>(instance.Keys[i], instance.Values[i]);
            }
        }
    
        public static int BinarySearch<TKey, TValue>(this SortedList<TKey, TValue> instance, TKey target) where TKey : IComparable<TKey>
        {
            int lo = 0;
            int hi = instance.Count - 1;
            while (lo <= hi)
            {
                int index = lo + ((hi - lo) >> 1);
                int compare = instance.Keys[index].CompareTo(target);
                if (compare == 0)
                {
                    return index;
                }
                else
                {
                    if (compare < 0)
                    {
                        lo = index + 1;
                    }
                    else
                    {
                        hi = index - 1;
                    }
                }
            }
            return ~lo;
        }
    }
