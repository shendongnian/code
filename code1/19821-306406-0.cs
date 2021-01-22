    public delegate bool ItemFilterDelegate(MyItem item);
    
    public IEnumerable<MyItem> FilterItems(ItemFilterDelegate filter)
    {
        var result = new List<MyItem>();
    
        foreach(MyItem item in AllItems)
        {
            if(filter(item))
                result.Add(item);
        }
    
        return item;
    }    
    public IEnumerable<MyItem> FilterByName(string name)
    {
        return FilterItems(item => item.Name == name);
    }
