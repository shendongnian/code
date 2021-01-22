    public class Order : Entity
    {
      [Field, Key]
      public int Id { get; set; }
      [Field, Association(PairTo = "Order")]
      public EntitySet<OrderItem> Items { get; private set; }
    }
    public class OrderItem : Entity
    {
      [Field, Key]
      public int Id { get; set; }
      [Field]
      public Order Order { get; set; }
    }
