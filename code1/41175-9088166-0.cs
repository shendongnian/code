    public interface ICart<TCartItem> where TCartItem : ICartItem
    {
        ...
        List<TCartItem> CartItems { get; set; }
    }
    public interface ICartItem
    {
        int ProductId { get; set; }
        int Quantity { get; set; }
    }
    public abstract class Cart : ICart<CartItem>
    {
        private List<CartItem> _cartItems = new List<CartItem>();
        public List<CartItem> CartItems 
        {
            get
            {
                return _cartItems;
            }
        }
    }
    public abstract class CartItem : ICartItem
    {
        ...
    }
