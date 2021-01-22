    public interface ISkuItem
    {
        string SKU { get; set; }
    }
    public interface ICartItem : ISkuItem
    {
        new string SKU { get; set; }
    }
    public class CartItem : ICartItem
    {
        public string SKU { get; set; }
    }
