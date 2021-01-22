    public interface ICart
    {
        ...
        List<ICartItem> CartItems { get; set; }
    }
    public interface ICartItem
    {
        int ProductId { get; set; }
        int Quantity { get; set; }
    }
    public abstract class Cart : ICart
    {
        private List<CartItem> _cartItems = new List<CartItem>();
        List<ICartItem> ICart.CartItems
        {
           get
           {
               return CartItems;
           }
        }
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
