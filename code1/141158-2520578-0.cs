    public class GroceryItem { 
       public string Name { get; set; }
       // ...
    }
    public class PurchaseLineItem
    {
        public double Price { get; set; }
        public int Quantity { get; set; }
        public GroceryItem Item { get; set; }
        // ...
    }
