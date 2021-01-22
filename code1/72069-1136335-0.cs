    public static int MaxIndex<T>(this IEnumerable<T> source)
    {
        IComparer<T> comparer = Comparer<T>.Default;
        using (var iterator = source.GetEnumerator())
        {
            if (!iterator.MoveNext())
            {
                throw new InvalidOperationException("Empty sequence");
            }
            int maxIndex = 0;
            T maxElement = iterator.Current;
            int index = 0;
            while (iterator.MoveNext())
            {
                index++;
                T element = iterator.Current;
                if (comparer.Compare(element, maxElement) > 0)
                {
                    maxElement = element;
                    maxIndex = index;
                }
            }
            return maxIndex;
        }
    }
