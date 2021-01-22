    public class Customer  : Contact
    {
       public ICollection<Order> Orders
       {
          get; private set;
          
       }
    }
