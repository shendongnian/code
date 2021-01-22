    HashSet<string> hashSet = new HashSet<string>();
    hashSet.Add("one");
    hashSet.Add("two");
    
    List<string> itemsToRemove = new List<string>();
    foreach (var item in hashSet)
    {
        if (item == "one")
        {
            itemsToRemove.Add(item);
        }
    }
    
    foreach (var item in itemsToRemove)
    {
        hashSet.Remove(item);
    }
