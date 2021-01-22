    // The items that match.
    IList<int> matched = new List<int>();
    
    // Scan 
    foreach (int b in ListB)
    {
        // The count.
        int count;
    
        // If the item is found in a.
        if (countsOfA.TryGetValue(b, out count))
        {
            // This is positive.
            Debug.Assert(count > 0);
    
            // Add the item to the list.
            matched.Add(b);
    
            // Decrement the count.  If
            // 0, remove.
            if (--count == 0) countsOfA.Remove(b);
        }
    }
