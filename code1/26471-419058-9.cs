    public static IEnumerable<IEnumerable<T>> GetEnumerableOfEnumerables<T>(
      IEnumerable<T> enumerable, int groupSize)
    {
       // The list to return.
       List<T> list = new List<T>(groupSize);
    
       // Cycle through all of the items.
       foreach (T item in enumerable)
       {
         // Add the item.
         list.Add(item);
    
         // If the list has the number of elements, return that.
         if (list.Count == groupSize)
         {
           // Return the list.
           yield return list;
    
           // Set the list to a new list.
           list = new List<T>(groupSize);
         }
       }
    
       // Return the remainder if there is any,
       if (list.Count != 0)
       {
         // Return the list.
         yield return list;
       }
    }
