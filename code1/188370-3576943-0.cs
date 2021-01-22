    public void Add(T item)
    {
        //...
        int count = this.items.Count;
        this.InsertItem(count, item);
    }
