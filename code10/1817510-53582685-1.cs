    internal sealed class ItemPool
    {
        private readonly ConcurrentDictionary<Guid, Item> items = new ConcurrentDictionary<Guid, Item>(); // Store all the items here
    
        public Item CreateItem()
        {
            Item itemToCreate = new Item();
            items.TryAdd(itemToCreate.Id, itemToCreate);
            return itemToCreate;
        }
    
        public void DestroyItem(Guid itemId)
        {
            activeItems.TryRemove(itemId, out Item _);
        }
    }
