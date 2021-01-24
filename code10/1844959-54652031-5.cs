    // Start with a list of the distinct firstList_names
    var union = new List<string>();
   
    foreach(var item in firstList_names)
    {
        if (!union.Contains(item))
        {
            union.Add(item);
        }
    }
    // Add any items from the secondList_names that don't exist
    foreach (var item in secondList_names)
    {
        if (!union.Contains(item))
        {
            union.Add(item);
        }
    }
