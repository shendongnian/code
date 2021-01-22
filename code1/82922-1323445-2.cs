    public class Product
    {
      public Int32 Id { get; private set; }
      public String Name { get; private set; }
    }
    public class ShoppingCartItem
    {
      public Product Product { get; private set; }
      public Int32 Quantity { get; set; }
    }
    public class ShoppingCart
    {
      public IList<ShoppingCartItem> Items { get; private set; }
    }
