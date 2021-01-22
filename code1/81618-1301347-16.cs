    public static IEnumerable<T> Slice<T>(this IEnumerable<T> source, int count)
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
            return SliceArray((T[]) source, count);
        }
        // Check to see if it is a list.
        if (source is IList<T>)
        {
            // Return the list slice.
            return SliceList ((IList<T>) source);
        }
        // Slice everything else.
        return SliceEverything(source, count);
    }
    private static IEnumerable<T> SliceArray<T>(T[] arr, int count)
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
    private static IEnumerable<T> SliceList<T>(IList<T> list, int count)
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
    // Helps with storing the sliced items.
    internal class SliceHelper<T> : IEnumerable<T>
    {
        // Creates a
        internal SliceHelper(IEnumerable<T> source, int count)
        {
            // Test assertions.
            Debug.Assert(source != null);
            Debug.Assert(count > 0);
    
            // Set up the backing store for the list of items
            // that are skipped.
            skippedItems = new List<T>(count);
    
            // Set the count and the source.
            this.count = count;
            this.source = source;
        }
    
        // The source.
        IEnumerable<T> source;
    
        // The count of items to slice.
        private int count;
    
        // The list of items that were skipped.
        private IList<T> skippedItems;
    
        // Expose the accessor for the skipped items.
        public IEnumerable<T> SkippedItems { get { return skippedItems; } }
    
        // Needed to implement IEnumerable<T>.
        // This is not supported.
        System.Collections.IEnumerator 
            System.Collections.IEnumerable.GetEnumerator()
        {
            throw new InvalidOperationException(
                "This operation is not supported.");
        }
    
        // Skips the items, but stores what is skipped in a list
        // which has capacity already set.
        public IEnumerator<T> GetEnumerator()
        {
            // The number of skipped items.  Set to the count.
            int skipped = count;
    
            // Cycle through the items.
            foreach (T item in source)
            {
                // If there are items left, store.
                if (skipped > 0)
                {
                    // Store the item.
                    skippedItems.Add(item);
    
                    // Subtract one.
                    skipped--;
                }
                else
                {
                    // Yield the item.
                    yield return item;
                }
            }
        }
    }
    private static IEnumerable<T> SliceEverything<T>(
        this IEnumerable<T> source, int count)
    {
        // Test assertions.
        Debug.Assert(source != null);
        Debug.Assert(count > 0);
        
        // Create the helper.
        SliceHelper<T> helper = new SliceHelper<T>(
            source, count);
    
        // Return the helper concatenated with the skipped
        // items.
        return helper.Concat(helper.SkippedItems);
    }
