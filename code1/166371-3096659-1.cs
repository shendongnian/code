    public static void Remove<T>(this IList list)
    {
        // Cycle through everything, comparing the types.
        for (int index = list.Count; index >= 0; --index)
        {
            // Get the object.
            object item = list[index];
    
            // If the item is null, continue.
            if (item == null) continue;
    
            // Remove the item if the types match.
            if (typeof(T) == item.GetType()) list.RemoveAt(index);
        } 
    }
