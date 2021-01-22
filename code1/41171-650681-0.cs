    public interface ICart<T> where T : ICartItem
    {
        // ...
        List<T> CartItems { get; set; }
    }
    
    public abstract class Cart : ICart<CartItem>
    {
        // ...
        public List<CartItem> CartItems { get; set; }
    }
