    // The dictionary.
    IDictionary<int, bool> dict = new Dictionary<int, bool>();
    
    // Cycle through the first list.
    foreach (int a in ListA)
    {
      // Add the number if it isn't in the set already.
      if (!dict.ContainsKey(a))
      {
        // Add the number.
        dict.Add(a, true);
      }
    }
    
    // The list that has the intersection.
    List<int> intersection = new List<int>();
    
    // Cycle through b.
    foreach (int b in ListB)
    {
      // If the dictionary contains the item, add to the intersection.
      if (dict.ContainsKey(b))
      {
        // Add to the intersection.
        intersection.Add(b);
      }
    }
