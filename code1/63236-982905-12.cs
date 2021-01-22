    public class Item
    {
        public Item() { }
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
