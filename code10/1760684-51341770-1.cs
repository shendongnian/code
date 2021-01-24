    const int MaxCount = 20;
    public List<item> myItems = new List<item>();
    public item_holder()
    {
        // Add 20 items to the list.
        for (int i = 0; i < MaxCount; i++) {
            myItems.Add(new item());
        }
    }
