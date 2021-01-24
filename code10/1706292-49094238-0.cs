    public class Item
    {
        private Lazy<BOM> _BOM;
        public Item(string name)
        {
            this.Name = name;  
            _BOM = new Lazy<BOM>(() => new BOM(name));
        }
        public string Name { get; private set; }
        public BOM BOM { get { return _BOM.Value; } }
    }
