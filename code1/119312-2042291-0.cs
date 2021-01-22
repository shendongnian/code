    public static bool ArraysEqual<T>(T[] first, T[] second)
    {
        if (first == second)
        {
            return true;
        }
        if (first == null || second == null)
        {
            return false;
        }
        if (first.Length != second.Length)
        {
            return false;
        }
        IEqualityComparer comparer = EqualityComparer<T>.Default;
        for (int i = 0; i < first.Length; i++)
        {
            if (!comparer.Equals(first[i], second[i]))
            {
                return false;
            }
        }
        return true;
    }
