    public static bool IsInRange<T>(T subject, T first, T last)
    {
        return IsInRange(subject, first, last, Comparer<T>.Default);
    }
    public static bool IsInRange<T>(T subject, T first, T last, IComparer<T> comparer)
    {
        return comparer.Compare(subject, first) >= 0 && comparer.Compare(subject, last) <= 0;
    }
