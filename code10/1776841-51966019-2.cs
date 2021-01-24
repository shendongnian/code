    public static class SortedListExtensions
    {
        public static SortedListFixed<TKey, TValue> ToFixedSize<TKey, TValue>(
            this SortedList<TKey, TValue> list) => new SortedListFixed<TKey, TValue>(list);
        
    }
