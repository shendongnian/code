    class Wrapper
    {
        private Collection<Item> _items;
        private string _name;
    
        public Collection<Item> Items { get {return _items; } set { _items = value; } }
        public string Name { get { return _name; } set { _name = value; } }
    }
