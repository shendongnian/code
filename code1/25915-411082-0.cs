    public class Item
    {
        private Item _parent;
        private List<Item> _children;
        public void Add(Item child)
        {
            if (child._parent != null)
            {
                throw new Exception("Child already has a parent");
            }
            _children.Add(child);
            child._parent=this;
        }
    }
