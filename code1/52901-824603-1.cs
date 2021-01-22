    public class Customer  : Contact
    {
       private ISet<Order> _orders = new HashedSet<Order>();
    
       public Collection<Order> Orders
       {
          return new List<Order>(_orders);
       }
       // NOrmally I would return a ReadOnlyCollection<T> instead of a Collection<T>
       // since I want to avoid that users add Orders directly to the collection.
       // If your relationship is bi-directional, then you have to set the other
       // end of the association as well, in order to hide this for the programmer
       // I always create add & remove methods (see below)
       public void AddOrder( Order o )
       {
          if( o != null && _orders.Contains(o) == false )
          {
             o.Customer = this;
             _orders.Add(o);
          }
       }
    }
