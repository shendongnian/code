    public class Customer  : Contact
    {
       private ISet<Order> _orders = new HashedSet<Order>();
    
       public ReadOnlyCollection Orders
       {
          return new List<Order>(_orders).AsReadOnly();
       }
    }
