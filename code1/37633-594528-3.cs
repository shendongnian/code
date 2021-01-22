    public static int FindFirstIndexGreaterThanOrEqualTo<T,U>(this SortedList<T,U> sortedList, T key) where T : IComparable<T>
    {
        return FindFirstIndexGreaterThanOrEqualTo(sortedList.Keys, key);
    }
    public static int BinarySearch<T>(this IList<T> sortedCollection, T value) where T : IComparable<T>
    {
        if (sortedCollection == null)
            throw new ArgumentNullException("sortedCollection");
        int begin = 0;
        int end = sortedCollection.Count - 1;
        int index = 0;
        while (end >= begin) {
            index = (begin + end) / 2;
            T val = sortedCollection[index];
            if (value == null && val == null)
                return index;
            int compare = val.CompareTo(value);
            if (compare == 0) 
                return index;
            if (compare > 0)
                end = index - 1;
            else
                begin = index + 1;
        }
        return ~index; // Not found, return bitwise complement of the index.
    }
    public static int FindFirstIndexGreaterThanOrEqualTo<T>(this IList<T> sortedCollection, T value) where T : IComparable<T>
    {
        int index = BinarySearch(sortedCollection, value);
        if (index < 0)
            index = ~index;
        while (index < sortedCollection.Count && sortedCollection[index].CompareTo(value) < 0)
            index++;
        while (index > 0 && sortedCollection[index - 1].CompareTo(value) == 0)
            index--;
        return index;
    }
