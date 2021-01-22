    public void AddRange(IEnumeratable<Item> items)
    {
        lock (_syncObject) // Locking only once.
        {
            foreach (Item item in items)
            {
                InsertItemImpl(item);
            }
        }
    }
    private void InsertItemImpl(Item item)
    {
         // inserting the item
    }
    public void InsertItem(Item item)
    {
        lock (_syncObject)
        {
            InsertItemImpl(item);
        }
    }
