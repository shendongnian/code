    class Order
    {
      public int number1 { get; set; }
      public int number2 { get; set; }
      ...
    }
    
    List<Order> orders = new List<Order>
    {
      { number1 = 123, number2 = 234 },
      { number1 = 321, number2 = 432 }
    };
