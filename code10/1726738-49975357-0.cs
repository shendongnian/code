    class GroceryItem
    {
        public string name;
        public double price;
        public PurchasedItem Purchased { get; private set; }
        public GroceryItem(string a, double b)
        {
            name = a;
            price = b;
            Purchased = new PurchasedItem(price);
        }
    }
  
    class PurchasedItem
    {
        public int quantity { get; set; }
        public double GroceryItemprice { get;private set; }
        public PurchasedItem(double price)
        {
            GroceryItemprice = price;
        }
        public double FindCost()
        {
            return GroceryItemprice * this.quantity * 1.10;
        }
        class FreshItem
        {
            public double weight;
        }
    }
