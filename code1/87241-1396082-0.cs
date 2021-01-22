    IEnumerable<IList<T>> PartitionList<T>(IList<T> list, int maxCount)
    {
        List<T> partialList = new List<T>(maxCount);
        foreach(T item in list)
        {
            if (partialList.Count == maxCount)
            {
               yield return partialList;
               partialList = new List<T>(maxCount);
            }
            partialList.Add(item);
        }
        if (partialList.Count > 0) yield return partialList;
    }
