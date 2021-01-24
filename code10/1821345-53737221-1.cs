    public static class Extension
    {
       public static IEnumerable<T> Circle<T>(this IEnumerable<T> list, int startIndex)
      {
        return list.Skip(startIndex).Concat(list.Take(startIndex));
      }
    
      public static void Fill<T>(this List<T> source, List<T> reference, int maxCount,ref int index)
      {
    	if(source.Count() >= maxCount) return;
    	
    	var difference = source.Count() - maxCount;
    	var newReferenceList = reference.Circle(index);
    	
        source.AddRange(newReferenceList.Where(x=>!source.Contains(x)).Take(maxCount- source.Count()));
    	index+=Math.Abs(difference);
    
    	if(index > maxCount) index = 0;
     }
    }
