    public static List<T> RemoveAndGet<T>(this List<T> list, Func<T, bool> predicate)
    {
        var itemsRemoved = new List<T>();
    
        // iterate backward for performance
        for (int i = list.Count - 1; i >= 0; i--)
        {
            // keep item pointer
            var item = list[i];
    
            // if the item match the remove predicate
            if (predicate(item))
            {
                // add the item to the returned list
                itemsRemoved.Add(item);
    
                // remove the item from the source list
                list.RemoveAt(i);
            }
        }
    
        return itemsRemoved;
    }
