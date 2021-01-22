    public Order FindOrderById(List<Order> orders, int id)
    {
      foreach (Order order in orders)
      {
        if (order.number1 == id || order.number2 == id)
        {
          return order;
        }
      }
    
      // None found.  Return null, throw exception, etc.
      return null;
    }
    
    ...
    
    List<Order> orders = new List<Order> { ... };
    Order foundOrder = FindOrderById(orders, 123);
    if (foundOrder == null)
    {
      //Not found
    }
    else
    {
      //Found
    }
