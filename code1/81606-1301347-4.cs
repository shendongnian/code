    public static IEnumerable<T> Slice(this IEnumerable<T> source, int count)
    {
        // If the enumeration is null, throw an exception.
        if (source == null) throw new ArgumentNullException("source");
    
        // Validate count.
        if (count < 0) throw new ArgumentOutOfRangeException("count", 
            "The count property must be a non-negative number.");
    
        // Short circuit, if the count is 0, just return the enumeration.
        if (count == 0) return source;
        // Is this an array?  If so, then take advantage of the fact it
        // is index based.
        if (source.GetType().IsArray)
        {
            // Return the array slice.
            return SliceArray(source, count);
        }
        // Check to see if it is a list.
        if (source is IList<T>)
        {
            // Return the list slice.
            return SliceList (source);
        }
        // Slice everything else.
        return source.Skip(count).Concat(source.Take(count));        
    }
    private static IEnumerable<T> SliceArray(T[] arr, int count)
    {
         // Error checking has been done, but use diagnostics or code
         // contract checking here.
         Debug.Assert(arr != null);
         Debug.Assert(count > 0);
    
         // Return from the count to the end of the array.
         for (int index = count; index < arr.Length; index++)
         {
              // Return the items at the end.
              yield return arr[index];
         }
    
         // Get the items at the beginning.
         for (int index = 0; index < count; index++)
         {
              // Return the items from the beginning.
              yield return arr[index];          
         }
    }
    private static IEnumerable<T> SliceList(IList<T> list, int count)
    {
         // Error checking has been done, but use diagnostics or code
         // contract checking here.
         Debug.Assert(list != null);
         Debug.Assert(count > 0);
    
         // Return from the count to the end of the list.
         for (int index = count; index < list.Count; index++)
         {
              // Return the items at the end.
              yield return list[index];
         }
    
         // Get the items at the beginning.
         for (int index = 0; index < list.Count; index++)
         {
              // Return the items from the beginning.
              yield return list[index];          
         }
    }
