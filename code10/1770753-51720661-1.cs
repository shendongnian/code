    public static class LinqHelpers
    {
        [Flags]
        public enum SortDirections
        {
            NotSorted = 0,
            Ascending = 1,
            Descending = 2,
        }
        public static SortDirections GetSortDirection<T>(this IEnumerable<T> input, IComparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            bool isAsc = true;
            bool isDsc = true;
            bool isFirst = true;
            T last = default(T);
            foreach (var val in input)
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    int cmp = comparer.Compare(last, val);
                    if (cmp > 0) isAsc = false;
                    if (cmp < 0) isDsc = false;
                }
                if (!isAsc && !isDsc) break;
                last = val;
            }
            int result = 0;
            if (isAsc) result |= (int)SortDirections.Ascending;
            if (isDsc) result |= (int)SortDirections.Descending;
            return (SortDirections)result;
        }
    }
