    public static void Rank<K>( IEnumerable<Data> source, Func<Data,K> rankBy ) where K : IComparable
    {
       int count = 1;
       foreach (var item in source.OrderBy( rankBy ))
       {
           item.R = count;
           ++count;
       }
    }
