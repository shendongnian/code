    public static Boolean CompareCollections<T>(IEnumerable<T> a, IEnumerable<T> b)
    {
        Dictionary<T, Int32> histogram = new Dictionary<T, Int32>();
        foreach (T item in a)
        {
            Int32 count;
            if (histogram.TryGetValue(item, out count))
            {
                histogram[item]++;
            }
            else
            {
                histogram[item] = 1;
            }
        }
        foreach (T item in b)
        {
            Int32 count;
            if (histogram.TryGetValue(item, out count))
            {
                if (count <= 0)
                {
                    return false;
                }
                histogram[item]--;
            }
            else
            {
                return false;
            }
        }
        foreach (Int32 value in histogram.Values)
        {
            if (value != 0)
            {
                return false;
            }
        }
        return true;
    }
