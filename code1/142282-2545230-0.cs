    list<int> itemsToDelete
    
    for(int i = 0; i < items.Count; i++)
    {
        if(shouldBeDeleted(items[i]))
        {
            itemsToDelete.Add(i);
        }
    }
    
    foreach(int index in itemsToDelete.Reverse())
    {
        items.RemoveAt(i);
    }
