    public void AddToStorage<TItem>(TItem item)
        where TItem: Item
    {    
        var storageList = Storage.Values.OfType<List<TItem>>().Single();
        storageList.Add(item);
    }
