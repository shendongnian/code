    public static IEnumerable<T> GetRank<T>(this Array source,int dimension, params int[] indexes )
    {
    
       var indexList = indexes.ToList();
       indexList.Insert(dimension, 0);
       indexes = indexList.ToArray();
    
       for (var i = 0; i < source.GetLength(dimension); i++)
       {
          indexes[dimension] = i;
          yield return (T)source.GetValue(indexes);
       }
    }
