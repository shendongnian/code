    public static bool IsSorted<T>(IEnumerable<T> input)
    {
        var comparer = Comparer<T>.Default;
        T previous = default(T);
        bool previousSet = false;
        int? comparisonOrder = null;
        foreach (var value in input)
        {
            if (!previousSet)
            {
                previous = value;
                previousSet = true;
            }
            else
            {
                int comparisonResult = comparer.Compare(previous, value);
                if (comparisonResult != 0)
                {
                    if (!comparisonOrder.HasValue)
                    {
                        comparisonOrder = comparisonResult;
                    }
                    else if (comparisonResult != comparisonOrder.Value)
                    {
                        return false;
                    }
                }
                previous = value;
            }
        }
        return true;
    }
