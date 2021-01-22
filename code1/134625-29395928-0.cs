    public class Item
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
    
        public IEnumerable<Item> GetChildItems(List<Item> allItems)
        {
            return allItems.Where(i => i.Id == this.ParentId);
        }
    }
    
    public class Tree
    {
        public List<Item> Items { get; set; }
    
        public IEnumerable<Item> RootItems(List<Item> allItems)
        {
            return allItems.Where(i => i.ParentId == null);
        }
    }
