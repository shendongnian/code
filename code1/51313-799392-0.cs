    public class ProductItem : OrderItem
    {
       public Item Item { get; set; }
       public string Description { get { return Item.Description; } }
       public int Quantity { get; set; }
       public decimal Amount { get { return Item.Price * Quantity; } }
    }
       
