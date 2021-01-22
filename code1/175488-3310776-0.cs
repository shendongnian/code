    public T Item 
    { 
        get { return item; } 
        set { item = value; } 
    } 
 
    public string GetItemAsString() 
    { 
        string itemString = Item.ToString(); 
 
        if(Item.GetType().IsArray) 
        { 
            itemString = String.Join(",", (Item as IEnumerable<object>).Select(item => item.ToString()).ToArray());
        } 
 
        return itemString; 
    }
