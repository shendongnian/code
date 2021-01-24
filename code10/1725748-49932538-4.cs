    public static Item GetNextItem(List<Item> items)
    {
        // If there are no existing items, return the default first item
        if (items == null || items.Count == 0) 
        {
            return new Item {PrimaryId = 1, SecondaryId = 1};
        }
        // Otherwise, grab the last item in the list
        var lastItem = items[items.Count - 1];
        // And use it's PrimaryId to determine the values for the next item's properties
        return new Item
        {
            PrimaryId = lastItem.PrimaryId + 1,
            SecondaryId = lastItem.PrimaryId % 2 == 0
                ? lastItem.PrimaryId + 1
                : lastItem.PrimaryId
        };
    }
