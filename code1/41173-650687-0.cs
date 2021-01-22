    public interface ICart<TCartItem> where TCartItem : ICartItem
    {
       List<TCartItem> CartItems { get; set; }
    }
    
    public interface ICartItem
    {
    }
    
    public abstract class Cart : ICart<CartItem>
    {
         public List<CartItem> { get; set; }
    }
    
    public abstract class CartItem : ICartItem
    {
    }
