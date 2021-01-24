    public static bool IsSorted<T>(IEnumerable<T> input)
    {
        var comparer = Comparer<T>.Default;
        T previous = default(T);
        bool previousSet = false;
        foreach (var value in input)
        {
            if (!previousSet)
            {
                previous = value;
                previousSet = true;
            }
            else
            {
                if (comparer.Compare(previous, value) > 0)
                {
                    return false;
                }
                previous = value;
            }
        }
        return true;
    }
