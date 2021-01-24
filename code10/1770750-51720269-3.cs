    public static bool IsSorted<T>(IEnumerable<T> input)
    {
        if (input is IOrderedEnumerable<T>)
        {
            return true;
        }
        var comparer = Comparer<T>.Default;
        T previous = default(T);
        bool previousSet = false;
        bool? comparisonOrder = null;
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
                        comparisonOrder = comparisonResult > 0;
                    }
                    else if (comparisonResult > 0 != comparisonOrder)
                    {
                        return false;
                    }
                }
                previous = value;
            }
        }
        return true;
    }
