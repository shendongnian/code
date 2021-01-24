    public Item itemPrefab;
    public Dictionary<string, Item> displayItems= new Dictionary<string, Item>();
    public void OnWoodClicked()
    {
        OnItemClicked("wood");
    }
    public void OnIronClicked()
    {
        OnItemClicked("iron");
    }
    private void OnItemClicked(string itemKey)
    {
        if (displayItems.ContainsKey(itemKey))
        {
            displayItems[itemKey].count++;
        }
        else
        {
            Item item = Instantiate(itemPrefab);
            item.count = 1;
            item.itemName=itemKey;
            displayItems.Add(itemKey, item);
        }
    }
    }
