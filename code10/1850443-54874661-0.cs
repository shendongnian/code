    public class CartItem
    {
        public decimal Price {get; set; }
        public int Quantity {get; set; }
        public decimal Cost { get { return Quantity*Price; } }
    }
