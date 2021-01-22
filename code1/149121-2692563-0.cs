    public void InsertItem(Item item)
    {
        AddRange(new IEnumeratable({item}))
    }
    public void AddRange(IEnumeratable<Item> items)
    {
        lock (_syncObject)
        {
            foreach (Item item in items)
            {
                // Insert code ..
            }
        }
    }
