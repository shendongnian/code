    public static int IndexOfMax(this IList<int> source)
    {
        if (source == null)
            throw new ArgumentNullException("source");
        if (source.Count == 0)
            throw new InvalidOperationException("List contains no elements");
    
        int maxValue = source[0];
        int maxIndex = 0;
        for (int i = 1; i < source.Count; i++)
        {
            int value = source[i];
            if (value > maxValue)
            {
                maxValue = value;
                maxIndex = i;
            }
        }
        return maxIndex;
    }
