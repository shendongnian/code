    public void ParseData(List<Item> items, String PropertyName)
    {
        foreach (Item item in items)
        {
            var prop = typeof(Item).GetProperty(PropertyName).GetValue(item, null);            
        }
    }
