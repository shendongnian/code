    public Boolean CompareCollections<T>(IEnumerable<T> a, IEnumerable<T> b)
    {
        Dictionary<T, Int32> histogram = new Dictionary<T, Int32>();
    
        foreach (T item in a)
        {
            histogram[Item]++;
        }
    
        foreach (T item in b)
        {
            histogram[Item]--;
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
