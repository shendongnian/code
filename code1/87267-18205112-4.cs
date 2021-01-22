    public static IEnumerable<IList<T>> Partition<T>(
        this IEnumerable<T> source,
        int size)
    {
        var partition = new T[size];
        count = 0;
        foreach (var t in source)
        {
            partition[count] = t;
            count++;
            if(count == size)
            {
                yield return partition;
                partition = new T[size];
                count = 0;
            }
        }
        if (count > 0)
        {
             Array.Resize(ref partition, count);
             yield return partition;
        }
    }
