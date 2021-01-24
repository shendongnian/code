    public class CartLine
    {
        public int CartLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
    
    public class ShoppingCart
    {
        public IList<CartLine> CartLines {get;set;}
    }
    
    
    ShoppingCart shoppingcart = new ShoppingCart();
