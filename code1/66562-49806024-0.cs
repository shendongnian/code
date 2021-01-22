    public static class ListExtensions
    {
       public static IEnumerable<TSource> ByIndexes<TSource>(this IList<TSource> source, params int[] indexes)
       {
           int currIndex = indexes[0];
    
           foreach (var i in indexes)
           {
               if (i >= 0 && i < source.Count)
                   yield return source[i];
           }
       }
    }
