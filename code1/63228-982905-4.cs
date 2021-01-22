    public class Item
    {
        public Item()
        {
            this.children = new ItemCollection(this);
        }
        public ItemCollection Children
        {
            get { return this.children; }
        }
        private readonly ItemCollection children = null;
        public Item Parent
        {
            get { return this.parent; }
            set
            {
                if (this.parent != null)
                {
                    this.parent.Children.Remove(this);
                }
                if (value != null)
                {
                    value.Children.Add(this);
                }
            }
        }
        private Item parent = null;
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
    }
