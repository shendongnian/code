    public class Item
    {
        // Constructor for an item without a parent.
        public Item() { }
    
        // Constructor for an item with a parent.
        public Item(Item parent)
        {
            // Use Parent property instead of parent field.
            this.Parent = parent;
        }
    
        public ItemCollection Children
        {
            get { return this.children; }
        }
        private readonly ItemCollection children = new ItemCollection(this);
