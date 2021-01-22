    public static Boolean CompareCollections<T>(ICollection<T> a, ICollection<T> b)
    {
        if (a.Count != b.Count)
        {
            return false;
        }
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
        return true;
    }
