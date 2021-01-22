    public static int MaxIndex(this IEnumerable<double> sequence)
    {
        int maxIndex = -1;
        double maxValue = 0; // Immediately overwritten anyway
        int index = 0;
        foreach (double value in sequence)
        {
            if (value > maxValue || maxIndex == -1)
            {
                 maxIndex = index;
                 maxValue = value;
            }
            index++;
        }
        return index;
    }
