    public static Item GetNextItem(List<Item> items)
    {
        if (items == null || items.Count == 0) 
        {
            return new Item {PrimaryId = 1, SecondaryId = 1};
        }
        var lastItem = items[items.Count - 1];
        return new Item
        {
            PrimaryId = lastItem.PrimaryId + 1,
            SecondaryId = lastItem.PrimaryId % 2 == 0
                ? lastItem.PrimaryId + 1
                : lastItem.PrimaryId
        };
    }
