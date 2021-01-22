    public static int BinarySearchBy<TSource,TKey>(this IList<TSource> list, 
        Func<TSource,TKey> projection, TKey key)
    {
        int min = 0;
        int max = list.Count-1;
    
        while (min <= max)
        {
            int mid = (min + max) / 2;
            TKey midKey = projection(list[mid]);
            int comparison = Comparer<TKey>.Default.Compare(midKey, key);
            if (comparison == 0)
            {
                return mid;
            }
            if (comparison < 0)
            {
                min = mid+1;
            }
            else
            {
                max = mid-1;
            }
        }
        return ~min;
    }
