    public class ItemCollection
    {
        private readonly Item parent = null;
        private readonly List<Item> items = null;
        public ItemCollection(Item parent)
        {
            this.items = new List<Item>();
            this.parent = parent;
        }
        public Item this[Int32 index]
        {
            get { return this.items[index]; }
        }
        public void Add(Item item)
        {
            if (!this.items.Contains(item))
            {
                this.items.Add(item);
                item.parent = this.parent;
            }
        }
        public void Remove(Item item)
        {
            if (this.items.Contains(item))
            {
                this.items.Remove(item);
                item.parent = null;
            }
        }
    }
