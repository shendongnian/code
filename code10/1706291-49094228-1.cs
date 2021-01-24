    public class Item
    {
        private Lazy<BOM> _BOM;
        public Item(string name)
        {
            this.Name = name;
            _BOM = new Lazy<BOM>(() => new BOM(Name));
        }
        public string Name { get; private set; }
        public BOM BOM { get { return _BOM.Value; } }
    }
    public class BOM
    {
        public BOM(string name)
        {
        }
    }
