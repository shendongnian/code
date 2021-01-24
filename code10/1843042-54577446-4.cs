    private static bool TryCombine(Item item1, Item item2, out Item combinedItem)
    {
        if (item2.Start - item1.End > TimeSpan.FromHours(1))
        {
            combinedItem = default;
            return false;
        }
    
        combinedItem = new Item { Start = item1.Start, End = item2.End };
        return true;
    }
