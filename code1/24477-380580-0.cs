    sealed class Order
    {
      public double SubTotal { get; set; }
      public double Shipping { get; set; }
    }
    static void Main()
    {
      var calculateTotal = DynamicExpression
        .ParseLambda<Order, double>("SubTotal*@0+Shipping", 0.12)
        .Compile();
    
      var order = new Order
      {
        SubTotal = 124.99,
        Shipping = 7.99
      };
      Console.WriteLine(calculateTotal(order));
      Console.ReadLine();
    }
