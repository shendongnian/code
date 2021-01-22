    public class Product
    {
        private List<string> _items; // indirect reference to the Items Product is associated with
        public List<string> Items
        {
            get
            {
                return _items;
            }
        }
        public Product(List<string> items)
        {
            _items = items;
        }
        public Item GetMaxItemSmth(IItemProcessor itemProcessor)
        {
            return itemProcessor.GetMaxItemSmth(this);
        }
    }
