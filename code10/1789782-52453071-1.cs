    public void AddToStorage<TItem>(TItem item)
        where TItem: Item, new()
    {    
        var storageList = Storage.Values.OfType<List<TItem>>().Single();
        storageList.Add(item);
    }
